using Godot;
using NovaDrift.Scripts;
using YAT.Attributes;
using YAT.Interfaces;
using YAT.Scenes;
using YAT.Types;

namespace YAT.Commands;

public static class GameCommands
{
	public static void RegisterCommands()
	{
		RegisteredCommands.AddCommand(typeof(UseAbilityById));
	}
}


[Command("UseAbilityById", "UseAbilityById [Id]")]
[Usage("UseAbilityById [Id]")]
[Argument("id", "int", "The id for the ability.")]
public sealed class UseAbilityById : ICommand
{
	public CommandResult Execute(CommandData data)
	{
		var id = (int)data.Arguments["id"];
		if (id == 0) return ICommand.Failure();
		DataBuilder.BuildAbilityById(id).Use();
		return ICommand.Success();
	}
}

// [ConsoleCommand("RemoveAllEffects")]
// public void RemoveAllEffects()
// {
// 	Global.Player.Stats.EffectSystem.RemoveAllEffects();
// }

// public sealed class PrintPlayerAbilities : ICommand
// {
// 	public CommandResult Execute(CommandData data)
// 	{
// 		// 	Console.Instance.Print($"玩家能力列表：", Console.PrintType.Success);
// 		foreach (var effect in Global.Player.Stats.EffectSystem.Effects)
// 		{
// 			Console.Instance.Print(effect.Name, Console.PrintType.Success);
// 		}
// 	}
//
// }

	
	
