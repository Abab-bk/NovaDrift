using System;
using FMOD;
using FMOD.Studio;
using Godot;
using GodotTask;

namespace AcidWallStudio.Fmod;

[GlobalClass]
public partial class SoundNode : Node2D
{
    public EventInstance EventInstance;
    
    public override void _Ready()
    {
        // EventInstance.setCallback(new EVENT_CALLBACK((type, @event, parameters) =>
        // {
        //     if (type == EVENT_CALLBACK_TYPE.SOUND_STOPPED)
        //     {
        //         GD.Print("QueueFree");
        //         DelayQueueFree();
        //     }
        //     return RESULT.OK;
        // } ), EVENT_CALLBACK_TYPE.SOUND_STOPPED);
        EventInstance.start();
        EventInstance.release();
    }

    private async void DelayQueueFree()
    {
        await GDTask.Delay(TimeSpan.FromSeconds(1), DelayType.Realtime);
        QueueFree();
    }

    public void Destroy()
    {
        EventInstance.stop(STOP_MODE.ALLOWFADEOUT);
        QueueFree();
    }

    public override void _PhysicsProcess(double delta)
    {
        EventInstance.set3DAttributes(GlobalPosition.ToFmodAttribute3D());
    }
}