using Godot;

namespace NovaDrift.addons.AcidUtilities;

public static class Node2DExtension
{
    public static float GetTweenRotation(this Node2D node)
    {
        if (node.RotationDegrees == 0f) return Mathf.Tau;
        return Mathf.DegToRad(0f);
    }
}