using System;
using Godot;

namespace AcidWallStudio.AcidUtilities;

public static class AcidSaver
{
    public static event Action OnLoaded;
    
    const string SettingsPath = "user://Settings.cfg";
    const string SaveDataPath = "user://SaveData.cfg";
    
    private static readonly ConfigFile Settings = new ConfigFile();
    private static readonly ConfigFile SaveData = new ConfigFile();
    
    public static void SaveAll()
    {
        Settings.Save(SettingsPath);
        SaveData.Save(SaveDataPath);
    }

    public static void LoadAll()
    {
        Settings.Load(SettingsPath);
        SaveData.Load(SaveDataPath);
        OnLoaded?.Invoke();
    }

    public static void AddSetting(string section, string key, Variant value) => Settings.SetValue(section, key, value);
    public static Variant GetSetting(string section, string key) { return Settings.GetValue(section, key); }
    public static bool HasSetting(string section, string key) { return Settings.HasSection(section) && Settings.HasSectionKey(section, key);}

    
    public static void AddSaveData(string section, string key, Variant value) => SaveData.SetValue(section, key, value);
    public static Variant GetSaveData(string section, string key) { return SaveData.GetValue(section, key); }
    public static bool HasSaveData(string section, string key) { return SaveData.HasSection(section) && SaveData.HasSectionKey(section, key); }
}