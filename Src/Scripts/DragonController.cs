using Godot;

namespace NovaDrift.Scripts;

[GlobalClass]
public partial class DragonController : Node2D
{
    [Export] private Node2D _dragonBones;
    
    private GodotObject _amature;
    
    public override void _Ready()
    {
        _amature = _dragonBones.Call("get_armature").AsGodotObject();
        Logger.Log("[DragonController] Ready, get amature: " + _amature);
    }
    
    public void Play(string name, int loopCount = -1)
    {
        _amature.Call("play", name, loopCount);
    }
}

static class Properties
{
    public const string
        Amature = "amature";
}