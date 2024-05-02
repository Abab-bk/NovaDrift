namespace NovaDrift.Scripts.Systems;

public interface IItemInfo
{
    public int Id { get; }
    public string Name { get; }
    public string Desc { get; }
    public string IconPath { get; }
    public string IconPath2 { get; }
    
    public void Use();
}