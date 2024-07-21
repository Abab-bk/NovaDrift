using AcidWallStudio.AcidUtilities;
using AcidWallStudio.Fmod;
using DsUi;
using Godot;
using NovaDrift.Scripts.Systems;

namespace NovaDrift.Scripts.Ui.Setting;

public partial class SettingPanel : Setting
{
    private static Control _currentColorBlindModePanel;
    private static int _currentColorBlindMode;
    
    public override void _Ready()
    {
        base._Ready();
        S_CloseBtn.Instance.Pressed += () =>
        {
            this.ChangeTo(UiManager.Create_StartMenu());
        };
        
        LoadAll();

        S_SoundVolumeSlider.Instance.ValueChanged += _ => { Save(); };
        S_MusicVolumeSlider.Instance.ValueChanged += _ => { Save(); };
        S_UiVolumeSlider.Instance.ValueChanged += _ => { Save(); };

        S_ColorBlindMode0.Instance.Pressed += () => { ChangeColorBlindMode(0); };
        S_ColorBlindMode1.Instance.Pressed += () => { ChangeColorBlindMode(1); };
        S_ColorBlindMode2.Instance.Pressed += () => { ChangeColorBlindMode(2); };
        S_ColorBlindMode3.Instance.Pressed += () => { ChangeColorBlindMode(3); };
        
        S_CdkeyBtn.Instance.Pressed += () =>
        {
            var lineEdit = new LineEdit()
            {
                PlaceholderText = "请输入兑换码",
                Alignment = HorizontalAlignment.Center,
                SizeFlagsHorizontal = SizeFlags.ShrinkCenter,
                CustomMinimumSize = new Vector2(1500f, 100f),
            };
            
            UiManager
                .Open_Popup()
                .SetConfig(
                    "兑换码",
                    "",
                    lineEdit,
                    true,
                    () => { },
                    () =>
                    {
                        var key = lineEdit.Text.Trim();
                        
                        if (key == "")
                        {
                            UiManager
                                .Open_Popup()
                                .SetConfig(
                                    "兑换码",
                                    "兑换码不能为空"
                                );
                            return;
                        }

                        var content = Encryptor.Decode(key);

                        if (Global.CdKeySaveNode.HasCdKey(key))
                        {
                            UiManager
                                .Open_Popup()
                                .SetConfig(
                                    "兑换码",
                                    "兑换码已使用"
                                );
                            return;
                        }

                        if (!Reward.ParseReward(content, out var reward))
                        {
                            UiManager
                                .Open_Popup()
                                .SetConfig(
                                    "兑换失败",
                                    "兑换码无效"
                                );
                            return;
                        }

                        UiManager
                            .Open_Popup()
                            .SetConfig(
                                "兑换成功",
                                reward.GetReward(),
                                false,
                                null,
                                () => Global.CdKeySaveNode.AddCdKey(key)
                            );
                    }
                );
        };
    }

    private void ChangeColorBlindMode(int mode)
    {
        if (_currentColorBlindModePanel != null)
        {
            _currentColorBlindModePanel.QueueFree();
            _currentColorBlindModePanel = null;
        }

        Control control = null;
        
        switch (mode)
        {
            case 0:
                _currentColorBlindMode = 0;
                break;
            case 1:
                _currentColorBlindMode = 1;
                control = GD.Load<PackedScene>("res://Scenes/Ui/ColorBlindMode1.tscn")
                            .Instantiate<Control>();
                break;
            case 2:
                _currentColorBlindMode = 2;
                control = GD.Load<PackedScene>("res://Scenes/Ui/ColorBlindMode2.tscn")
                        .Instantiate<Control>();
                break;
            case 3:
                _currentColorBlindMode = 3;
                control = GD.Load<PackedScene>("res://Scenes/Ui/ColorBlindMode3.tscn")
                        .Instantiate<Control>();
                break;
        }

        if (control != null)
        {
            _currentColorBlindModePanel = control;
            UiManager.GetUiLayer(UiLayer.Pop).AddChild(control);
        }
        
        Save();
    }

    public override void OnCreateUi()
    {
    }

    private void LoadAll()
    {
        S_UiVolumeSlider.Instance.SetValueNoSignal(
            AcidSaver.HasSetting("Audios", "Ui") ? (float)AcidSaver.GetSetting("Audios", "Ui") : 80f
            );
        S_MusicVolumeSlider.Instance.SetValueNoSignal(
            AcidSaver.HasSetting("Audios", "MusicVolume") ? (float)AcidSaver.GetSetting("Audios", "MusicVolume") : 80f
            );
        S_SoundVolumeSlider.Instance.SetValueNoSignal(
            AcidSaver.HasSetting("Audios", "SoundVolume") ? (float)AcidSaver.GetSetting("Audios", "SoundVolume") : 80f
            );
        _currentColorBlindMode = AcidSaver.HasSetting("Accessibility", "ColorBlindMode") ? (int)AcidSaver.GetSetting("Accessibility", "ColorBlindMode") : 0;
        
        ChangeColorBlindMode(_currentColorBlindMode);
        
        SetVolumes();
    }

    private void Save()
    {
        AcidSaver.AddSetting("Audios", "Ui", S_UiVolumeSlider.Instance.Value);
        AcidSaver.AddSetting("Audios", "MusicVolume", S_MusicVolumeSlider.Instance.Value);
        AcidSaver.AddSetting("Audios", "SoundVolume", S_SoundVolumeSlider.Instance.Value);
        AcidSaver.AddSetting("Accessibility", "ColorBlindMode", _currentColorBlindMode);
        AcidSaver.SaveAll();
        
        SetVolumes();
    }

    private void SetVolumes()
    {
        SoundManager.MusicVolume = (float)S_MusicVolumeSlider.Instance.Value;
        SoundManager.SfxVolume = (float)S_SoundVolumeSlider.Instance.Value;
        SoundManager.UiSoundsVolume = (float)S_UiVolumeSlider.Instance.Value;
        SoundManager.SetVolume();
    }

    public override void OnDestroyUi()
    {
        
    }

}
