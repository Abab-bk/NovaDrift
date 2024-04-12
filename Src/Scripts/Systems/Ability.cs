namespace NovaDrift.Scripts.Systems;

public class Ability : IItemInfo
{
    public string Name { get; set; }
    public string Desc { get; set; }
    public string ClassName;
    public Effect Effect;
    
    public void Use()
    {
        Global.Player.Stats.AddEffect(Effect);
    }
}