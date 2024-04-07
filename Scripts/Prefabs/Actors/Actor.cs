using Godot;
using System;
using NovaDrift.Scripts.Frameworks.Architectures;
using NovaDrift.Scripts.Frameworks.Commands;

namespace NovaDrift.Scripts.Prefabs.Actors;

[GlobalClass]
public partial class Actor : CharacterBody2D, ICanSendCommand
{
    public IArchitecture GetArchitecture()
    {
        return ActorArchitecture.Interface;
    }
}
