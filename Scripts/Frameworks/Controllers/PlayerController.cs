using NovaDrift.Scripts.Frameworks.Architectures;
using NovaDrift.Scripts.Frameworks.Models;

namespace NovaDrift.Scripts.Frameworks.Controllers;

public class PlayerController : IController
{
    private PlayerModel _playerModel;
    
    private void Start()
    {
        _playerModel = this.GetModel<PlayerModel>();
    }

    private void UpdateView()
    {
        
    }

    public IArchitecture GetArchitecture()
    {
        return PlayerArchitecture.Interface;
    }

    private void OnDestroy()
    {
        _playerModel = null;
    }
}