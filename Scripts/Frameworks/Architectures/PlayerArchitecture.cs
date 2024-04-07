using NovaDrift.Scripts.Frameworks.Models;

namespace NovaDrift.Scripts.Frameworks.Architectures;

public class PlayerArchitecture : Architecture<PlayerArchitecture>
{
    protected override void Init()
    {
        RegisterModel(new PlayerModel());
    }
}