namespace NovaDrift.addons.AcidStats;

public class StatModifier
{
    public float Value;
    public readonly StatModType Type;
    public readonly int Order;
    public readonly object Source; // Added this variable
 
    // "Main" constructor. Requires all variables.
    public StatModifier(float value, StatModType type, int order, object source) // Added "source" input parameter
    {
        Value = value;
        Type = type;
        Order = order;
        Source = source; // Assign Source to our new input parameter
    }
 
    // Requires Value and Type. Calls the "Main" constructor and sets Order and Source to their default values: (int)type and null, respectively.
    public StatModifier(float value, StatModType type) : this(value, type, (int)type, null) { }
 
    // Requires Value, Type and Order. Sets Source to its default value: null
    public StatModifier(float value, StatModType type, int order) : this(value, type, order, null) { }
 
    // Requires Value, Type and Source. Sets Order to its default value: (int)Type
    public StatModifier(float value, StatModType type, object source) : this(value, type, (int)type, source) { }
}