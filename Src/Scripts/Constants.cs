using Godot;

namespace NovaDrift.Scripts;

public static class Constants
{
    public static class Colors
    {
        public static readonly WorldColor Red = new WorldColor
        {
            Level1 = new Color(1f, 0.5f, 0.5f)
        };

        public static readonly WorldColor Blue = new WorldColor
        {
            Level1 = new Color(0.5f, 0.5f, 1f)
        };   
    }
    
    public class WorldColor
    {
        public Color Level1 = new Color(0.5f, 0.5f, 0.5f);
    }
}