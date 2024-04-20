using media.Laura.SofiaConsole;

namespace NovaDrift.Scripts.Systems;

public class GameCommands
{
    [ConsoleCommand("UseAbilityById", Usage = "UseAbilityById [Id]")]
    public void UseAbilityById(int id)
    {
        DataBuilder.BuildAbilityById(id).Use();
    }

    [ConsoleCommand("PrintPlayerAbilities")]
    public void PrintPlayerAbilities()
    {
        Console.Instance.Print($"玩家能力列表：", Console.PrintType.Success);
        foreach (var effect in Global.Player.Stats.EffectSystem.Effects)
        {
            Console.Instance.Print(effect.Name, Console.PrintType.Success);
        }
    }
}