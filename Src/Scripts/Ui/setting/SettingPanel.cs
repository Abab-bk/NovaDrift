using AcidWallStudio.Fmod;
using Godot;
using NovaDrift.addons.AcidUtilities;

namespace NovaDrift.Scripts.Ui.Setting;

public partial class SettingPanel : Setting
{
    public override void _Ready()
    {
        base._Ready();
        S_CloseBtn.Instance.Pressed += OpenPrevUi;
        
        AcidSaver.LoadAll();
        LoadAll();

        S_SoundVolumeSlider.Instance.ValueChanged += _ => { Save(); };
        S_MusicVolumeSlider.Instance.ValueChanged += _ => { Save(); };
        S_UiVolumeSlider.Instance.ValueChanged += _ => { Save(); };
    }

    public override void OnCreateUi()
    {
    }

    private void LoadAll()
    {
        S_UiVolumeSlider.Instance.SetValueNoSignal(AcidSaver.HasSetting("Audios", "Ui") ? (float)AcidSaver.GetSetting("Audios", "Ui") : 80f);
        S_MusicVolumeSlider.Instance.SetValueNoSignal(AcidSaver.HasSetting("Audios", "MusicVolume") ? (float)AcidSaver.GetSetting("Audios", "MusicVolume") : 80f);
        S_SoundVolumeSlider.Instance.SetValueNoSignal(AcidSaver.HasSetting("Audios", "SoundVolume") ? (float)AcidSaver.GetSetting("Audios", "SoundVolume") : 80f);
        
        SetVolumes();
    }

    private void Save()
    {
        AcidSaver.AddSetting("Audios", "Ui", S_UiVolumeSlider.Instance.Value);
        AcidSaver.AddSetting("Audios", "MusicVolume", S_MusicVolumeSlider.Instance.Value);
        AcidSaver.AddSetting("Audios", "SoundVolume", S_SoundVolumeSlider.Instance.Value);
        AcidSaver.SaveAll();
        
        SetVolumes();
    }

    private void SetVolumes()
    {
        Fmod.MusicVolume = (float)S_MusicVolumeSlider.Instance.Value;
        Fmod.SfxVolume = (float)S_SoundVolumeSlider.Instance.Value;
        Fmod.UiSoundsVolume = (float)S_UiVolumeSlider.Instance.Value;
        Fmod.SetVolume();
    }

    public override void OnDestroyUi()
    {
        
    }

}
