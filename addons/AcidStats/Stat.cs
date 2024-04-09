using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NovaDrift.addons.AcidStats;

public enum StatModType
{
    Flat = 100,
    PercentAdd = 200, // Add this new type.
    PercentMult = 300, // Change our old Percent type to this.
}


public class Stat
{
    public delegate void ValueChangedHandler(float newValue);
    public event ValueChangedHandler ValueChangedEvent;
    
    public float BaseValue;
    
    private float _lastBaseValue = float.MinValue;
    private float _value;
    
    public float Value {
        get {
            if(!_lastBaseValue.Equals(BaseValue)) {
                _lastBaseValue = BaseValue;
                _value = CalculateFinalValue();
            }
            return _value;
        }
    }

    private readonly List<StatModifier> _statModifiers;
    public readonly ReadOnlyCollection<StatModifier> StatModifiers;

    public Stat(float baseValue)
    {
        BaseValue = baseValue;
        _statModifiers = new List<StatModifier>();
        StatModifiers = _statModifiers.AsReadOnly();
    }
 
    private int CompareModifierOrder(StatModifier a, StatModifier b)
    {
        if (a.Order < b.Order)
            return -1;
        else if (a.Order > b.Order)
            return 1;
        return 0; // if (a.Order == b.Order)
    }
    
    public void AddModifier(StatModifier mod)
    {
        _statModifiers.Add(mod);
        _statModifiers.Sort(CompareModifierOrder);
        ValueChangedEvent?.Invoke(Value);
    }
    
    public bool RemoveModifier(StatModifier mod)
    {
        if (_statModifiers.Remove(mod))
        {
            ValueChangedEvent?.Invoke(Value);
            return true;
        }

        _statModifiers.Remove(mod);
        ValueChangedEvent?.Invoke(Value);
        return false;
    }
 
    private float CalculateFinalValue()
    {
        float finalValue = BaseValue;
        float sumPercentAdd = 0; // This will hold the sum of our "PercentAdd" modifiers
 
        for (int i = 0; i < _statModifiers.Count; i++)
        {
            StatModifier mod = _statModifiers[i];
 
            if (mod.Type == StatModType.Flat)
            {
                finalValue += mod.Value;
            }
            else if (mod.Type == StatModType.PercentAdd) // When we encounter a "PercentAdd" modifier
            {
                sumPercentAdd += mod.Value; // Start adding together all modifiers of this type
 
                // If we're at the end of the list OR the next modifer isn't of this type
                if (i + 1 >= _statModifiers.Count || _statModifiers[i + 1].Type != StatModType.PercentAdd)
                {
                    finalValue *= 1 + sumPercentAdd; // Multiply the sum with the "finalValue", like we do for "PercentMult" modifiers
                    sumPercentAdd = 0; // Reset the sum back to 0
                }
            }
            else if (mod.Type == StatModType.PercentMult) // Percent renamed to PercentMult
            {
                finalValue *= 1 + mod.Value;
            }
        }
 
        return (float)Math.Round(finalValue, 4);
    }
    
    public bool RemoveAllModifiersFromSource(object source)
    {
        bool didRemove = false;
 
        for (int i = _statModifiers.Count - 1; i >= 0; i--)
        {
            if (_statModifiers[i].Source == source)
            {
                didRemove = true;
                _statModifiers.RemoveAt(i);
            }
        }
        return didRemove;
    }
}