using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GodotGetNode;

[Generator] public class GetNodeGenerator : ISourceGenerator {
    public void Initialize(GeneratorInitializationContext context) {
        context.RegisterForPostInitialization(ctx => {
            ctx.AddSource("GetNode.cs",
                """
                using System;

                [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
                public class GetNode : Attribute {
                    public string NodePath { get; private set; }
                    public GetNode() : this(string.Empty) { }
                    public GetNode(string nodePath) {
                        NodePath = nodePath;
                    }
                }
                """);
            ctx.AddSource("NoAutoGetNodes.cs",
                """
                using System;

                [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
                public class NoAutoGetNodes : Attribute { }
                """);
        });
        context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
    }

    public void Execute(GeneratorExecutionContext context) {
        if (context.SyntaxContextReceiver is not SyntaxReceiver receiver)
            return;
        foreach (var it in receiver.WorkItems) {
            var (ns, cls) = ToNamespaceAndClass(it.Key);
            var ctor = it.Value.AutoGetNodes ? $"public {cls}() {{ TreeEntered += GetNodes; }}" : "";
            var code = $$"""
                         using Godot;
                         {{ns}}
                         partial class {{cls}} {
                             {{ctor}}
                             public void GetNodes() {
                                 {{string.Join("\n        ", it.Value.CodeLines)}}
                             }
                         }
                         """;
            var log = string.Join("\n", receiver.Log);
            context.AddSource($"{cls}.g.cs", $"{log}\n{code}");
        }
    }

    private static (string ns, string cls) ToNamespaceAndClass(string s) {
        var i = s.LastIndexOf('.');
        var ns = i == -1 ? "" : $"namespace {s.Substring(0, i)};";
        var cls = s.Substring(i + 1);
        return (ns, cls);
    }
}

class ClassData(bool autoGetNodes) {
    public bool AutoGetNodes { get; } = autoGetNodes;
    public List<string> CodeLines { get; } = new();
}

class SyntaxReceiver : ISyntaxContextReceiver {
    public List<string> Log { get; } = new();
    public readonly Dictionary<string, ClassData> WorkItems = new();

    public void OnVisitSyntaxNode(GeneratorSyntaxContext context) {
        try {
            if (context.Node is not FieldDeclarationSyntax fieldDeclarationSyntax) return;
            foreach (var it in fieldDeclarationSyntax.Declaration.Variables) {
                var field = (IFieldSymbol)context.SemanticModel.GetDeclaredSymbol(it)!;
                var attr = field.GetAttributes().FirstOrDefault(x => x.AttributeClass?.Name == "GetNode");
                if (attr == null) continue;
                var type = field.ContainingType.ToString();
                if (type == null) continue;
                if (!WorkItems.TryGetValue(type, out var d)) {
                    var autoGetNodes = !field.ContainingType.GetAttributes().Any(a =>
                        a.AttributeClass?.Name == "NoAutoGetNodes");
                    d = new ClassData(autoGetNodes);
                    WorkItems.Add(type, d);
                }

                var (parent, path) = ToNodePath(attr.ConstructorArguments, field.Name);
                d.CodeLines.Add($"{field.Name} = {parent}GetNode<{field.Type.Name}>(\"{path}\");");
            }
        } catch (Exception ex) {
            Log.Add("Error parsing syntax: " + ex);
        }
    }

    private static (string, string) ToNodePath(ImmutableArray<TypedConstant> args, string fieldName) {
        var path = args.IsEmpty ? "" : args.First().Value as string ?? "";
        var i = path.IndexOf('.');
        var parent = path.Substring(0, i + 1);
        path = path.Substring(i + 1);
        if (path is "" or "%") {
            fieldName = fieldName.TrimStart(['_']);
            path += char.ToUpper(fieldName[0]) + fieldName.Substring(1);
        }

        return (parent, path);
    }
}