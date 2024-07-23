using System.Collections.Generic;
using Godot;
using KaimiraGames;
using NovaDrift.addons.AcidUtilities;
using NovaDrift.Scripts.Prefabs.Components;

namespace NovaDrift.Scripts;

public static class Constants
{
    public static Vector2 DefaultPoolPos = new Vector2(-10000f, -10000f);
    public const string SavePath = "user://save.dat";
    
    public static class Points
    {
        public const string
            TopLimit = "TopLimit",
            BottomLimit = "BottomLimit",
            LeftLimit = "LeftLimit",
            RightLimit = "RightLimit",
            LeftUpLimit = "LeftUpLimit",
            LeftDownLimit = "LeftDownLimit",
            RightUpLimit = "RightUpLimit",
            RightDownLimit = "RightDownLimit",
            Limit = "Limit",
            RandomCorner = "RandomCorner",
            LeftUp = "LeftUp",
            Left = "Left",
            LeftDown = "LeftDown",
            Down = "Down",
            RightDown = "RightDown",
            Right = "Right",
            RightUp = "RightUp",
            Up = "Up",
            RandomLeft = "RandomLeft",
            RandomRight = "RandomRight",
            RandomUp = "RandomUp",
            RandomDown = "RandomDown",
            Center = "Center";
    }
    
    public static class Tags
    {
        public const string
            IsDragonBone = "IsDragonBone",
            IsDisabledRotation = "IsDisabledRotation";
    }
    
    public static class Colors
    {
        public static readonly WorldColor Red = new WorldColor
        {
            Level1 = new Color("ff7578")
        };

        public static readonly WorldColor Blue = new WorldColor
        {
            Level1 = new Color("7591ff")
        };

        public static readonly WorldColor Green = new WorldColor
        {
            Level1 = new Color("75ffac")
        };
    }
    
    public class WorldColor
    {
        public Color Level1 = new Color(0.5f, 0.5f, 0.5f);
    }
}