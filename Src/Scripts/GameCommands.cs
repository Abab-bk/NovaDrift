using Godot;
using NovaDrift.Scripts;
using NovaDrift.Scripts.Prefabs.Components;
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
		RegisteredCommands.AddCommand(typeof(UseShooterById));
		RegisteredCommands.AddCommand(typeof(GenerateMobById));
	}
}


[Command("GenerateMobById", "GenerateMobById [Id]")]
[Argument("id", "int", "The id for the mob.")]
public sealed class GenerateMobById : ICommand
{
	public CommandResult Execute(CommandData data)
	{
		MobSpawner.GenerateMobByIdAction?.Invoke((int)data.Arguments["id"]);
		return ICommand.Success();
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

[Command("UseShooterById", "UseShooterById [Id]")]
[Usage("UseShooterById [Id]")]
[Argument("id", "int", "The id for the shooter.")]
public sealed class UseShooterById : ICommand
{
	public CommandResult Execute(CommandData data)
	{
		var id = (int)data.Arguments["id"];
		if (id == 0) return ICommand.Failure();
		DataBuilder.BuildWeaponById(id).Use();
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

	
	
