using System;
using System.Linq;
using AcidWallStudio.AcidUtilities;
using AcidWallStudio.Fmod;
using DsUi;
using Godot;

namespace NovaDrift.Scripts.Systems.Buffs;

public class Madness : Buff
{
    public int Strength = 1; // 实际上是层级

    private Timer _voiceTimer;
    
    public override void OnCreate()
    {
        _voiceTimer = new Timer
        {
            WaitTime = 0.5f,
            OneShot = true,
        };
        Global.GameWorld.AddChild(_voiceTimer);
        _voiceTimer.Timeout += PlayVoice;
        ShowToUi();
        PlayVoice();
    }

    private void PlayVoice()
    {
        SoundManager.PlayOneShotById("event:/Mobs/Bosses/TheDoctor/Voice");
        _voiceTimer.WaitTime = Random.Shared.FloatRange(6f, 12f);
        _voiceTimer.Start();
    }

    protected override void ShowToUi()
    {
        var hud = UiManager.Get_Hud_Instance().First();
        if (hud == null) return;
        hud.AddBuffIcon(this);
    }
}