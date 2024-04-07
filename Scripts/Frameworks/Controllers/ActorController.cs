using NovaDrift.Scripts.Frameworks.Architectures;
using NovaDrift.Scripts.Frameworks.Models;

namespace NovaDrift.Scripts.Frameworks.Controllers;

public class ActorController : IController
{
    private ActorModel _actorModel;
    
    private void Start()
    {
        _actorModel = this.GetModel<ActorModel>();
    }

    private void UpdateView()
    {
        
    }

    public IArchitecture GetArchitecture()
    {
        return ActorArchitecture.Interface;
    }

    private void OnDestroy()
    {
        _actorModel = null;
    }
}