using System.Numerics;
using NovaDrift.Scripts.Frameworks.Stats;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Frameworks.Models;

public class ActorModel : AbstractModel
{
    public CharacterStats CharacterStats;
    public Actor Actor;
    
    protected override void OnInit()
    {
        CharacterStats = new CharacterStats();
    }
}