# C# GetNode for Godot 4.0+

C# equivalent to @onready in GDScript

## Install

Assume you have a Godot project in `parentDir/MyProject/MyProject.csproj`

+ clone GodotGetNode `parentDir/GodotGetNode`
+ Add to `MyProject.csproj`:

```xml

<ItemGroup>
  <ProjectReference Include="..\GodotGetNode\GodotGetNode.csproj"
                    ReferenceOutputAssembly="false"
                    OutputItemType="Analyzer"/>
</ItemGroup>
```

## Usage

+ Add `GetNode` attribute to a field

```csharp
public partial class MyNode : Node {
    [GetNode] Control _node1;
    [GetNode] Label node2;
    [GetNode] Button Node3;
    [GetNode("%")] Label _node4;
    [GetNode("%CustomePath")] Label node5;
    [GetNode("Custome/Path/Label")] Label node6;
    [GetNode("_node1.") Label _node7;
}
```

=> generated code:

```csharp
partial class MyNode {
    public MyNode() { TreeEntered += GetNodes; }
    public void GetNodes() {
        // Case 1: [GetNode] without params
        // NodePath: strip '_' prefix and change first char to upper case
        _node1 = GetNode<Control>("Node1"); // _node1 -> Node1
        node2 = GetNode<Label>("Node2"); // node2 -> Node2
        Node3 = GetNode<Button>("Node3"); // Node3 -> Node3 (same)
        
        // Case 2: [GetNode("%")] -> Add '%' (unique) prefix
        _node4 = GetNode<Label>("%Node4");
        
        // Case 3: [GetNode(custom_path)] -> Use custom_path as is
        node5 = GetNode<Label>("%CustomePath");
        node6 = GetNode<Label>("Custome/Path/Label");
        
        // Case 4: [GetNode(parentVar.path)] ->
        //  + Use GetNode on `parentVar` instead of `this`
        //  + path can be empty or have % prefix or be a custom_path like in cases 1,2,3
        _node7 = _node1.GetNode<Label>("Node7");
  }
}
```

+ Add `[NoAutoGetNodes]` if you don't want to generate the constructor:

```csharp
[NoAutoGetNodes] public partial class MyNode : Node {
    [GetNode] Control _node1;
    public override void _Ready() {
        GetNodes();
        // don something with _node
    }
}
```

Generated code:
```csharp
partial class MyNode {
    public void GetNodes() {
        _node1 = GetNode<Control>("Node1");
    }
}
```

See also: https://github.com/31/GodotOnReady/issues/49
