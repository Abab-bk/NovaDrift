using System;
using GDebugPanelGodot.DebugActions.Widgets;
using Godot;
using NovaDrift.addons.AcidStats;

namespace NovaDrift.Scripts.Systems.Debugs;

public partial class AbilityDebugActionWidget : DebugActionWidget
{
    [Export] public Label Label;
    [Export] public OptionButton StatButton;
    [Export] public OptionButton TypeButton;
    [Export] public LineEdit ValueEdit;
    [Export] public Button ApplyButton;

    enum Stats
    {
        BulletSize,
    }

    enum Types
    {
        Flat,
        PercentAdd,
        PercentMult,
    }

    public override void _Ready()
    {
        Init();
    }

    public void Init()
    {
        foreach (var stat in Enum.GetValues<Stats>())
        {
            StatButton.AddItem(stat.ToString());
        }
        
        foreach (var type in Enum.GetValues<Types>())
        {
            TypeButton.AddItem(type.ToString());
        }

        ApplyButton.Pressed += () =>
        {
            switch (StatButton.Selected)
            {
                case (int)Stats.BulletSize:
                    Global.Player.Stats.BulletSize.AddModifier(new StatModifier(
                        float.Parse(ValueEdit.Text), GetModifierType()));
                    Logger.Log($"[Debug] Add bullet size modifier: {ValueEdit.Text}");
                    break;
            }
        };
    }

    private StatModType GetModifierType()
    {
        switch (TypeButton.Selected)
        {
            case (int)Types.Flat:
                return StatModType.Flat;
            case (int)Types.PercentMult:
                return StatModType.PercentMult;
            case (int)Types.PercentAdd:
                return StatModType.PercentAdd;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}