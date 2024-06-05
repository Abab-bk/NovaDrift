using Godot;
using System;
using System.Collections.Generic;
using GTweens.Builders;
using GTweensGodot.Extensions;
using NovaDrift.Scripts.Prefabs.Actors;

namespace NovaDrift.Scripts.Prefabs.Others;
public partial class BlackHole : Node2D
{
	public event Action<Actor> OnActorEnter;
	public event Action OnDead;
	
	private float _mass = 20000f;
	
	public List<Actor> ExceptActors = new();
	public float Radius = 400f;
	public int Life = 5;
	
	public override void _Ready()
	{
		GTweenSequenceBuilder.New()
			.Append(this.TweenRotation(360f, 1f).SetLoops(Life))
			.AppendCallback(() =>
			{
				foreach (var actor in GetTree().GetNodesInGroup("Actors"))
				{
					if (actor is not Actor node2D) continue;
					if (ExceptActors.Contains(node2D)) continue;
					node2D.Stats.ForceVector = Vector2.Zero;
				}
				
				OnDead?.Invoke();
			})
			.Build()
			.Play();
		Scale = new Vector2(Radius / 700f, Radius / 700f);
		_mass = Radius * 30f;
	}

	public override void _PhysicsProcess(double delta)
	{
		Apply();
	}

	private void Apply()
	{
		foreach (var actor in GetTree().GetNodesInGroup("Actors"))
		{
			if (actor is not Actor node2D) continue;
			if (ExceptActors.Contains(node2D)) continue;
			
			var dir = node2D.GlobalPosition.DirectionTo(GlobalPosition);
			var distance = GlobalPosition.DistanceTo(node2D.GlobalPosition);
			var force = _mass / distance;
			var forceVector = dir * force;
			node2D.Stats.ForceVector = forceVector;

			if (node2D.GlobalPosition.DistanceTo(GlobalPosition) <= 200)
			{
				OnActorEnter?.Invoke(node2D);
			}
		}
	}
}
