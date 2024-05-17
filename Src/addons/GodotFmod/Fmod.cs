using Godot;
using System;
using FMOD.Studio;

namespace AcidWallStudio.Fmod;

public static class Fmod
{
    private static FMOD.Studio.System _studioSystem;

    public static float MasterVolume = 1;
    public static float MusicVolume = 1;
    public static float SfxVolume = 1;
    public static float UiSoundsVolume = 1;

    private static Bus _masterBus;
    private static Bus _musicBus;
    private static Bus _sfxBus;
    private static Bus _uiSoundsBus;
    
    public static void PlayOneShotById(string id)
    {
        var soundInstance = CreateInstanceById(id);
        soundInstance.start();
    }

    public static EventInstance CreateInstanceById(string id)
    {
        var desc = _studioSystem.getEvent(id, out var soundDesc);
        soundDesc.createInstance(out var instance);
        return instance;
    }

    public static void Shutdown()
    {
        _studioSystem.release();
    }

    public static void Initialize()
    {
        FMOD.Studio.System.create(out _studioSystem);
        _studioSystem.initialize(FmodConfig.MaxChannels, INITFLAGS.NORMAL, FMOD.INITFLAGS.NORMAL, IntPtr.Zero);
        
        foreach (var path in FmodConfig.BankPaths)
        {
            _studioSystem.loadBankFile(path, LOAD_BANK_FLAGS.NORMAL, out var bank);
        }
        
        _studioSystem.getBus("bus:/", out _masterBus);
        _studioSystem.getBus("bus:/Music", out _musicBus);
        _studioSystem.getBus("bus:/SFX", out _sfxBus);
        _studioSystem.getBus("bus:/UI", out _uiSoundsBus);
    }

    public static void SetVolume()
    {
        _masterBus.setVolume(MasterVolume);
        _musicBus.setVolume(MusicVolume);
        _sfxBus.setVolume(SfxVolume);
        _uiSoundsBus.setVolume(UiSoundsVolume);
    }

    public static void Update()
    {
        _studioSystem.update();
    }
}
