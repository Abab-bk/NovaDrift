using AcidWallStudio.AcidUtilities;
using Godot;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class Wardens : MobAiComponent
{
    private Vector2 _dir;

    public override void _Ready()
    {
        base._Ready();
        _dir = Wizard.GetRandom8Dir();
    }

    protected override void ConnectProcessSignals(State state, float delta)
    {
        base.ConnectProcessSignals(state, delta);
        switch (state.GetName())
        {
            case "Moving":
                Mob.TryMoveTo(_dir, delta);
                break;
        }
    }
}
