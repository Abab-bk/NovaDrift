using NovaDrift.Scripts.Frameworks.Models;

namespace NovaDrift.Scripts.Frameworks.Architectures;

public class ActorArchitecture : Architecture<ActorArchitecture>
{
    protected override void Init()
    {
        RegisterModel(new ActorModel());
    }
}