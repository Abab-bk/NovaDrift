using Godot;
using System;
using FMOD.Studio;

namespace NovaDrift.Scripts;

public partial class AudioSystem : Node
{
    public static AudioSystem Instance { get; private set; }

    public Bank MasterBank;
    public Bank MasterStringsBank;
    public Bank SfxBank;
    private FMOD.Studio.System _studioSystem;
    
    public static void Awake()
    {
        if (Instance != null) throw new Exception("Has already been initialized!");
        Instance = new AudioSystem();
        Instance.Init();
    }
    
    public static AudioSystem GetInstance()
    {
        if (Instance == null) throw new Exception("Has not been initialized!");
        return Instance;
    }

    private void Init()
    {
        FMOD.Studio.System.create(out _studioSystem);
        _studioSystem.initialize(32, INITFLAGS.NORMAL, FMOD.INITFLAGS.NORMAL, IntPtr.Zero);
        _studioSystem.loadBankFile("Assets/Audios/Banks/MasterStrings.bank", LOAD_BANK_FLAGS.NORMAL, out MasterStringsBank);
        _studioSystem.loadBankFile("Assets/Audios/Banks/Master.bank", LOAD_BANK_FLAGS.NORMAL, out MasterBank);
        _studioSystem.loadBankFile("Assets/Audios/Banks/SFX.bank", LOAD_BANK_FLAGS.NORMAL, out SfxBank);
    }

    public void PlayOneShotByGuid(string id)
    {
        var sound = _studioSystem.getEvent(id, out var soundDesc);
        soundDesc.loadSampleData();
        soundDesc.createInstance(out var soundInstance);
        soundInstance.start();
    }

    public void Update()
    {
        _studioSystem.update();
    }
}
