using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AcidWallStudio.AcidUtilities;
using AcidWallStudio.Fmod;
using FMOD.Studio;
using Godot;
using GTweens.Builders;
using GTweens.Extensions;
using GTweensGodot.Extensions;
using NovaDrift.Scripts.Prefabs.Components;
using NovaDrift.Scripts.Systems;
using NovaDrift.Scripts.Systems.Buffs;
using NovaDrift.Scripts.Vfx;
using Timer = Godot.Timer;

namespace NovaDrift.Scripts.Prefabs.Ai;

public partial class TheDoctorAi : MobAiComponent
{
    // private Timer _shockTimer;
    // private int _movePointIndex;
    //
    // private Node2D _darkClouds;
    // private Bank _bank;
    //
    // private readonly (Vector2 Pos, Vector2 Offset, float Angle)[] _darkCloudsPos =
    // {
    //     (new Vector2(-300, Wizard.GetScreenCenterY()), new Vector2(400, 0), 90), // Left
    //     (new Vector2(Wizard.GetMaxScreenX() + 300f, Wizard.GetScreenCenterY()), new Vector2(-400, 0), 90), // Right
    //     (new Vector2(Wizard.GetScreenCenterX(), -300), new Vector2(0, 400), 0), // Up
    //     (new Vector2(Wizard.GetScreenCenterX(), Wizard.GetMaxScreenY() + 300f), new Vector2(0, -400), 0) // Down
    // };
    //
    // private readonly ActionData _shock1ActionData = new ActionData(0.2f ,0.2f, 0.3f);
    // private readonly ActionData _shock2ActionData = new ActionData(0.2f ,0.2f, 0.3f);
    // private readonly (float Min, float Max) _attackRange = (2f, 4f);
    //
    // public override async void _Ready()
    // {
    //     base._Ready();
    //     Mob.IsBoss = true;
    //     await ToSignal(Owner, Node.SignalName.Ready);
    //     // Mob.Spring.RemoveTargetPoint(Global.Player);
    //     SetMovePoint();
    //
    //     SoundManager.LoadBank("TheDoctor.bank", out _bank);
    //     
    //     _shockTimer = new Timer
    //     {
    //         WaitTime = Random.Shared.FloatRange(_attackRange.Min, _attackRange.Max),
    //         OneShot = true
    //     };
    //     Mob.AddChild(_shockTimer);
    //     _shockTimer.Timeout += () =>
    //     {
    //         _shockTimer.WaitTime = Random.Shared.FloatRange(_attackRange.Min, _attackRange.Max);
    //         switch (Random.Shared.Next(0, 2))
    //         {
    //             case 0:
    //                 Machine.SetTrigger("ToShockThepary1");
    //                 // Machine.SetTrigger("ToShockThepary2");
    //                 break;
    //             case 1:
    //                 Machine.SetTrigger("ToShockThepary2");
    //                 // Machine.SetTrigger("ToShockThepary1");
    //                 break;
    //         }
    //     };
    //     
    //     SetNewPos();
    // }
    //
    // protected override void OnMobDied()
    // {
    //     _bank.unload();
    //     base.OnMobDied();
    // }
    //
    // protected override void ConnectProcessSignals(State state, float delta)
    // {
    //     base.ConnectProcessSignals(state, delta);
    //     switch (state.GetName())
    //     {
    //         case "WalkingOnEdge":
    //             Mob.SetTargetAndMove(MovePoint, delta);
    //             if (Mob.Position.DistanceTo(MovePoint.GlobalPosition) < 40f)
    //             {
    //                 SetNewPos();
    //             }
    //
    //             break;
    //     }
    // }
    //
    // protected override void ConnectEnteredSignals(State state)
    // {
    //     base.ConnectEnteredSignals(state);
    //     switch (state.GetName())
    //     {
    //         case "WalkingOnEdge":
    //             SetNewPos();
    //             _shockTimer.Start();
    //             break;
    //         case "ShockThepary1":
    //             ShockThepary1();
    //             break;
    //         case "ShockThepary2":
    //             ShockThepary2();
    //             break;
    //     }
    // }
    //
    // private void ShockThepary2()
    // {
    //     void LineCallback(Polyline2D line, int i)
    //     {
    //         if (i == 0) Machine.SetTrigger("ToWalking");
    //         line.QueueFree();
    //     }
    //
    //     Mob.LookAt(Global.Player.GlobalPosition);
    //     for (int i = 0; i < 8; i++)
    //     {
    //         var line = new Polyline2D();
    //         line.DefaultColor = new Color("7b1cf4");
    //         line.Width = 60f;
    //         Mob.AddChild(line);
    //         line.Area2D.SetIsPlayer(false);
    //         line.Modulate = new Color("7b1cf46a");
    //
    //         var count = i;
    //         
    //         GTweenSequenceBuilder.New()
    //             .Append(line.TweenModulate(new Color("7b1cf4"), _shock2ActionData.PreparationTime).OnComplete(() =>
    //             {
    //                 SoundManager.PlayOneShotById("event:/Mobs/Bosses/TheDoctor/Lightning");
    //                 if (!line.Area2D.OverlapsBody(Global.Player)) return;
    //                 Global.Player.TakeDamageWithoutKnockBack(Mob.Stats.Damage.Value);
    //                 TryToAddBuff();
    //             }))
    //             .AppendTime(_shock2ActionData.Duration)
    //             .Append(line.TweenModulateAlpha(0f, _shock2ActionData.RecoveryTime))
    //             .AppendCallback(() =>
    //             {
    //                 LineCallback(line, count);
    //             })
    //             .Build()
    //             .Play();
    //     }
    // }
    //
    // private async void ShockThepary1()
    // {
    //     await CreateDarkClouds();
    //
    //     var rectCount = 4;
    //     var padding = 200f;
    //     
    //     var cloudPos = _darkCloudsPos
    //         .Where(p => p.Pos + p.Offset == _darkClouds.GlobalPosition)
    //         .PickRandom();
    //     
    //     (Vector2 Pos, float Angle, float Height) GetRectPosByIndex(int index, RectDangerZoneIndicator zone)
    //     {
    //         if (cloudPos.Angle.Equals(90f))
    //         {
    //             // Left or Right
    //             var pos = new Vector2(0, Wizard.GetMaxScreenY() / rectCount * (index + 1) - padding);
    //             return (pos, 0f, 230f);
    //         }
    //         if (cloudPos.Angle.Equals(0f))
    //         {
    //             // Top or Bottom
    //             var pos = new Vector2(Wizard.GetMaxScreenX() / rectCount * (index + 1) - padding, Wizard.GetScreenCenterY());
    //             return (pos, 90f, 430f);
    //         }
    //         
    //         throw new Exception("Unknown cloudPos.Angle: " + cloudPos.Angle);
    //
    //     }
    //     
    //     async void ToWalkingFromShockThepary1()
    //     {
    //         await DestroyDarkClouds();
    //         Machine.SetTrigger("ToWalking");
    //     }
    //
    //     for (int i = 0; i < 4; i++)
    //     {
    //         var zone =
    //             GD.Load<PackedScene>("res://Scenes/Vfx/RectDangerZoneIndicator.tscn").Instantiate() as
    //                 RectDangerZoneIndicator;
    //         if (zone == null) return;
    //
    //         var zonePos = GetRectPosByIndex(i, zone);
    //         zone.IsPlayer = false;
    //         zone.Size = new Vector2(Wizard.GetMaxScreenX(), zonePos.Height);
    //         zone.ActionData = _shock1ActionData;
    //         
    //         Global.GameWorld.AddChild(zone);
    //         
    //         zone.GlobalPosition = zonePos.Pos;
    //         zone.RulePosition();
    //         zone.RotationDegrees = zonePos.Angle;
    //         
    //         zone.OnAnimationEnd += () =>
    //         {
    //             var lightning = GD.Load<PackedScene>("res://Scenes/Vfx/Lightning.tscn").Instantiate() as Lightning;
    //             if (lightning == null) return;
    //             
    //             lightning.Size = zone.Size;
    //             Global.GameWorld.AddChild(lightning);
    //             lightning.GlobalPosition = zone.GlobalPosition;
    //             lightning.RotationDegrees = zone.RotationDegrees;
    //             
    //             SoundManager.PlayOneShotById("event:/Mobs/Bosses/TheDoctor/Lightning");
    //             
    //             if (zone.Area2D.OverlapsBody(Global.Player))
    //             {
    //                 Global.Player.TakeDamageWithoutKnockBack(Mob.Stats.Damage.Value);
    //                 TryToAddBuff();
    //             }
    //             
    //             ToWalkingFromShockThepary1();
    //         };
    //         
    //     }
    // }
    //
    // private void TryToAddBuff()
    // {
    //     var checkBuff = Global.Player.Stats.BuffSystem.HasBuffById(1002);
    //     if (checkBuff != null && checkBuff is Madness madness)
    //     {
    //         madness.LevelUp();
    //         return;
    //     }
    //
    //     if (DataBuilder.BuildBuffById(1002) is not Madness buff) return;
    //     buff.TheDoctor = Mob;
    //     Global.Player.Stats.AddBuff(buff);
    // }
    //
    // private Task CreateDarkClouds()
    // {
    //     _darkClouds = GD.Load<PackedScene>("res://Scenes/Vfx/DarkClouds.tscn").Instantiate() as Node2D;
    //     if (_darkClouds == null) throw new Exception("DarkClouds is null");
    //
    //     var pos = _darkCloudsPos.PickRandom();
    //     
    //     Logger.Log($"[Ai] CreateDarkClouds: {pos.Pos} {pos.Angle} Final Pos: {pos.Pos + pos.Offset}");
    //     
    //     Global.GameWorld.AddChild(_darkClouds);
    //     _darkClouds.Show();
    //     _darkClouds.GlobalPosition = pos.Pos;
    //     _darkClouds.RotationDegrees = pos.Angle;
    //
    //     var tw = _darkClouds.TweenGlobalPosition(pos.Pos + pos.Offset, 2f);
    //     tw.Play();
    //     
    //     return tw.AwaitCompleteOrKill(new CancellationToken());
    // }
    //
    // private Task DestroyDarkClouds()
    // {
    //     var pos = _darkCloudsPos
    //         .Where(p => p.Pos + p.Offset == _darkClouds.GlobalPosition)
    //         .PickRandom();
    //     
    //     var tw = _darkClouds.TweenGlobalPosition(pos.Pos, 2f);
    //     tw.Play();
    //     return tw.AwaitCompleteOrKill(new CancellationToken());
    // }
    //
    // protected override void ConnectExitedSignals(State state)
    // {
    //     base.ConnectExitedSignals(state);
    //     switch (state.GetName())
    //     {
    //         case "WalkingOnEdge":
    //             // Mob.CleanTarget();
    //             Mob.Velocity = Vector2.Zero;
    //             break;
    //     }
    // }
    //
    // private void SetNewPos()
    // {
    //     MovePoint.GlobalPosition = Wizard.GetMapCornerByIndex(_movePointIndex);
    //     _movePointIndex += 1;
    //     if (_movePointIndex > 3) _movePointIndex = 0;
    // }
}
