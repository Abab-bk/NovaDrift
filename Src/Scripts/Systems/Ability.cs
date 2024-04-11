namespace NovaDrift.Scripts.Systems;

public class Ability
{
    public string Name;
    public string Desc;
    public string ClassName;
    public Effect Effect;

    public void Use()
    {
        Global.Player.Stats.AddEffect(Effect);
    }
}