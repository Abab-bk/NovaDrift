using Godot;
using NovaDrift.Scripts.Frameworks.Stats;

namespace NovaDrift.Scripts.Prefabs.Actors;

[GlobalClass]
public partial class Actor : CharacterBody2D
{
    public CharacterStats CharacterStats = new CharacterStats();
}
