using Godot;

namespace NovaDrift.Scripts;

public partial class Test : Node2D
{
    public override void _Ready()
    {
        for (int i = 0; i < DataBuilder.Constants.MaxLevel; i++)
        {
            GD.Print($"{i} {DataBuilder.GetNextLevelExp(i)}");
        }
    }
}
