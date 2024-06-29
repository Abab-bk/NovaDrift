using System;
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
        if (_amature == null) return;
        if (name == _amature.Get("current_animation").ToString()) return;
        _amature.Call("stop", _amature.Get("current_animation"), true);
        _amature.Call("play", name, loopCount);
    }

    public void FlipY(bool value)
    {
        if (_amature == null) return;
        _amature.Set("flip_y", value);
    }
    
    public void FlipX(bool value)
    {
        if (_amature == null) return;
        _amature.Set("flip_x", value);
    }
}