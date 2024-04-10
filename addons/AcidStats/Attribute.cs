using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Godot;

namespace NovaDrift.addons.AcidStats;

public class Attribute
{
    public event Action<float> ValueChanged;
    public event Action<float> ValueToMax;
    
    public float BaseValue = 0f;
    
    public Stat MaxValue = new Stat(100f);
    public float MinValue = 0;

    private readonly List<StatModifier> _statModifiers;
    public readonly ReadOnlyCollection<StatModifier> StatModifiers;
    
    public Attribute(float minValue, float maxValue)
    {
        MinValue = minValue;
        MaxValue = new Stat(maxValue);
        _statModifiers = new List<StatModifier>();
        StatModifiers = _statModifiers.AsReadOnly();
    }

    public Attribute()
    {
        _statModifiers = new List<StatModifier>();
        StatModifiers = _statModifiers.AsReadOnly();
    }
    
    public bool ValueIsMax()
    {
        if (BaseValue >= MaxValue.Value)
        {
            ValueToMax?.Invoke(BaseValue);
            return true;
        }

        return false;
    }

    public void Increase(float amount)
    {
        BaseValue += amount;
        ValueChanged?.Invoke(BaseValue);
        ValueIsMax();
    }

    public void Decrease(float amount)
    {
        BaseValue -= amount;
        ValueChanged?.Invoke(BaseValue);
        ValueIsMax();
    }

    public bool ValueIsMin()
    {
        return BaseValue <= MinValue;
    }

    public void Replenish()
    {
        _statModifiers.Clear();
        BaseValue = MaxValue.Value;
        ValueChanged?.Invoke(BaseValue);
        ValueIsMax();
    }
    
    public void Clear()
    {
        _statModifiers.Clear();
        BaseValue = 0;
    }
}