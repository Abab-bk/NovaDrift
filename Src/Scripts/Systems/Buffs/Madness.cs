using System;
using System.Linq;
using AcidWallStudio.AcidUtilities;
using AcidWallStudio.Fmod;
using DsUi;
using Godot;
using NovaDrift.Scripts.Prefabs.Actors.Mobs;
using NovaDrift.Scripts.Ui.BuffIcon;

namespace NovaDrift.Scripts.Systems.Buffs;

public class Madness : Buff
{
    public MobBase TheDoctor;
    
    private int _level = 1; // 实际上是层级
    private int _maxLevel = 9;
    
    private Timer _voiceTimer;
    private Timer _scareTimer;
    
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

    public void LevelUp()
    {
        if (_level == _maxLevel) return;
        _level = Mathf.Min(_level + 1, _maxLevel);
        Logger.Log("[Buff] Madness level up. Strength: " + _level);
        ShowToUi();
        
        if (_level == 6)
        {
            if (_scareTimer != null) _scareTimer.QueueFree();
            _scareTimer = new Timer()
            {
                WaitTime = 0.5f,
                OneShot = true,
            };
            _scareTimer.Timeout += JumpScare;
            Global.GameWorld.AddChild(_scareTimer);
            _scareTimer.Start();
            return;
        }

        if (_level == 9)
        {
            TheDoctor.Modulate = TheDoctor.Modulate with {A = 0f};
        }

    }
    
    public void LevelDown()
    {
        _level = Mathf.Max(_level - 1, 0);
        Logger.Log("[Buff] Madness level down. Strength: " + _level);
        
        if (_level == 0)
        {
            Destroy();
            return;
        }

        if (_level < 6)
        {
            if (_scareTimer != null) _scareTimer.QueueFree();
        }
        
        if (_level < 9)
        {
            TheDoctor.Modulate = TheDoctor.Modulate with {A = 1f};
        }

        ShowToUi();
    }

    protected override void Destroy()
    {
        base.Destroy();
        _voiceTimer.QueueFree();
        if (_scareTimer != null) _scareTimer.QueueFree();
    }

    private void PlayVoice()
    {
        SoundManager.PlayOneShotById("event:/Mobs/Bosses/TheDoctor/Voice");
        _voiceTimer.WaitTime = Random.Shared.FloatRange(6f, 12f);
        _voiceTimer.Start();
    }

    private void JumpScare()
    {
        // SoundManager.PlayOneShotById("event:/Mobs/Bosses/TheDoctor/JumpScare");
        Node2D scare = GD.Load<PackedScene>("res://Scenes/Vfx/DoctorScare.tscn").Instantiate() as Node2D;
        if (scare == null) return;
        Global.GameWorld.AddChild(scare);
        _scareTimer.WaitTime = Random.Shared.FloatRange(2f, 4f);
        _scareTimer.Start();
    }

    protected override void ShowToUi()
    {
        var hud = UiManager.Get_Hud_Instance().First();
        if (hud == null) return;
        
        BuffIconPanel getBuff = hud.GetBuffIcon(this);
        
        if (getBuff == null)
        {
            hud.AddBuffIcon(this, GetRatio());
            return;
        }
        
        // --- Animation ---
        var animationPanel = UiManager.Create_BuffIcon();
        animationPanel.UpdateUi(this);
        animationPanel.ShowUi();
        animationPanel.UpdateUiWithAnimation(this, GetRatio(), GetRatioByLevel(Mathf.Min(_level - 1, 1)));
        // ----------------
        
        getBuff.UpdateProgressBar(GetRatio());
    }

    public override float GetRatio()
    {
        return GetRatioByLevel(_level);
    }
    
    private float GetRatioByLevel(int level)
    {
        return (float)level / _maxLevel * 100f;
    }
}