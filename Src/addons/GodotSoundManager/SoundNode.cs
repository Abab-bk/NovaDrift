using FMOD;
using FMOD.Studio;
using Godot;

namespace AcidWallStudio.Fmod;

[GlobalClass]
public partial class SoundNode : Node2D
{
    public EventInstance EventInstance;
    
    public override void _Ready()
    {
        EventInstance.setCallback(new EVENT_CALLBACK((type, @event, parameters) =>
        {
            if (type == EVENT_CALLBACK_TYPE.SOUND_STOPPED)
            {
                QueueFree();
            }
            return RESULT.OK;
        } ), EVENT_CALLBACK_TYPE.SOUND_STOPPED);
        EventInstance.start();
        EventInstance.release();
    }

    public override void _PhysicsProcess(double delta)
    {
        EventInstance.set3DAttributes(GlobalPosition.ToFmodAttribute3D());
    }
}