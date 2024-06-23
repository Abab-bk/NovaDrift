using Godot;
using System;
using FMOD;
using FMOD.Studio;
using INITFLAGS = FMOD.Studio.INITFLAGS;

namespace AcidWallStudio.Fmod;

public static class SoundManager
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
    
    private static EventInstance _currentMusicInstance;
    
    public static void PlayOneShotById(string id)
    {
        var instance = CreateInstanceById(id);
        instance.start();
        instance.release();
    }

    public static void PlayMusic(string id)
    {
        if (_currentMusicInstance.isValid()) _currentMusicInstance.release();
        _currentMusicInstance = CreateInstanceById(id);
        _currentMusicInstance.start();
    }

    public static void SetMusicParameter(string para, int value)
    {
        if (_currentMusicInstance.isValid())
        {
            _currentMusicInstance.setParameterByName(para, value);
        }
    }

    public static float GetMusicParameter(string para)
    {
        if (_currentMusicInstance.isValid())
        {
            _currentMusicInstance.getParameterByName(para, out var value);
            return value;
        }
        return 0;
    }

    public static void PlayUiSound(string id)
    {
        PlayOneShotById(id);
    }
    
    public static ATTRIBUTES_3D ToFmodAttribute3D(this Vector2 source)
    {
        return new ATTRIBUTES_3D
        {
            position = new VECTOR
            {
                x = source.X,
                y = -source.Y,
                z = 0,
            },
            forward = new VECTOR
            {
                x = 1,
                y = 0,
            },
            up = new VECTOR
            {
                x = 0,
                y = -1,
            }
        };
    }

    public static EventInstance PlaySound(string id, Vector2 position)
    {
        var instance = CreateInstanceById(id);
        instance.set3DAttributes(position.ToFmodAttribute3D());
        instance.start();
        return instance;
    }
    
    public static EventInstance PlaySound(string id)
    {
        var instance = CreateInstanceById(id);
        instance.start();
        return instance;
    }

    public static EventInstance CreateInstanceById(string id)
    {
        var desc = _studioSystem.getEvent(id, out var soundDesc);
        if (desc != RESULT.OK) Logger.LogError($"Error loading sound {desc.ToString()}");
        
        var instanceResult = soundDesc.createInstance(out var instance);
        if (instanceResult != RESULT.OK) Logger.LogError($"Error creating instance {instanceResult.ToString()}");
        
        return instance;
    }

    public static void Shutdown()
    {
        _studioSystem.release();
    }

    public static void Initialize()
    {
        FMOD.Studio.System.create(out _studioSystem);
        _studioSystem.initialize(FmodConfig.MaxChannels, INITFLAGS.NORMAL, FMOD.INITFLAGS._3D_RIGHTHANDED, IntPtr.Zero);

        foreach (var path in FmodConfig.BankPaths)
        {
            _studioSystem.loadBankFile(path, LOAD_BANK_FLAGS.NORMAL, out var bank);
        }
        
        _studioSystem.getBus("bus:/", out _masterBus);
        _studioSystem.getBus("bus:/Music", out _musicBus);
        _studioSystem.getBus("bus:/SFX", out _sfxBus);
        _studioSystem.getBus("bus:/UI", out _uiSoundsBus);
    }
    
    public static void LoadBank(string fileName, out Bank bank)
    {
        var result = _studioSystem.loadBankFile(FmodConfig.RootPath + fileName, LOAD_BANK_FLAGS.NORMAL, out bank);
        if (result != RESULT.OK) Logger.LogError($"Error loading bank {result.ToString()}");
    }

    public static void SetVolume()
    {
        if (!_masterBus.isValid()) return;
        _masterBus.setVolume(MasterVolume);
        _musicBus.setVolume(MusicVolume);
        _sfxBus.setVolume(SfxVolume);
        _uiSoundsBus.setVolume(UiSoundsVolume);
    }

    public static void Update()
    {
        // 更新 Listener（玩家） 属性
        if (FmodConfig.Listener != null)
        {
            var playerAttribute = new ATTRIBUTES_3D
            {
                position = new VECTOR
                {
                    x = FmodConfig.Listener.GlobalPosition.X,
                    y = -FmodConfig.Listener.GlobalPosition.Y,
                    z = 1,
                },
                forward = new VECTOR
                {
                    x = 1,
                    y = 0,
                },
                up = new VECTOR
                {
                    x = 0,
                    y = -1,
                }
            };
            _studioSystem.setListenerAttributes(0, playerAttribute);
        }

        _studioSystem.update();
    }
}
