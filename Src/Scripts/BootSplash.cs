using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AcidWallStudio.AcidUtilities;
using Godot;
using GodotTask;
using GTweens.Builders;
using GTweens.Extensions;
using GTweensGodot.Extensions;
using NathanHoad;
using NovaDrift.Scripts.Systems.Pool;
using Timer = Godot.Timer;

namespace NovaDrift.Scripts;

public partial class BootSplash : Control
{
    [GetNode("%ProgressBar")] private ProgressBar _progressBar;
    [GetNode("AnimationPlayer")] private AnimationPlayer _animationPlayer;
    [GetNode("MinLoadingTimer")] private Timer _minLoadingTimer;
    [GetNode("%LoadingLabel")] private Label _loadingLabel;
    
    private const string Path = "res://Scenes/World.tscn";
    
    public override void _Ready()
    {
        InputHelper.Instance.Connect("device_changed", Callable.From((string device, int index) =>
        {
            Logger.Log($"[Device]: {device} (in slot ${index})");
            switch (device)
            {
                case InputHelper.DEVICE_XBOX_CONTROLLER:
                    Global.CurrentInputDevice = InputDevice.Joystick;
                    break;
                case InputHelper.DEVICE_KEYBOARD:
                    Global.CurrentInputDevice = InputDevice.Keyboard;
                    break;
                case InputHelper.DEVICE_GENERIC:
                    Global.CurrentInputDevice = InputDevice.VirtualJoystick;
                    break;
            }
        }));
        
        if (OS.GetName() == "Windows" || OS.GetName() == "macOS" || OS.GetName() == "Linux")
        {
            Global.AcidCoins += 1000;
            Global.CurrentPlatform = GamePlatform.Desktop;
            // Global.CurrentPlatform = GamePlatform.Mobile;
        }
        else if (OS.GetName() == "Android" || OS.GetName() == "iOS")
        {
            Global.CurrentPlatform = GamePlatform.Mobile;
        }
        
        Logger.Log("[BootSplash] Booting...");
        
        _progressBar.Value = 0;
        
        if (Global.IsDebugMode())
        {
            Logger.Log("[BootSplash] Debug mode, change scene to: " + Path);
            Loading();
            return;
        }
        
        _animationPlayer.AnimationFinished += _ =>
        {
            _minLoadingTimer.Start();
            Loading();
        };
        _animationPlayer.Play("Run");
    }
    
    private void Loading()
    {
        GameWorld loadedNode;
        
        async void ChangeScene(GameWorld node)
        {
            if (!_minLoadingTimer.IsStopped() && !Global.IsDebugMode())
            {
                Logger.Log("[UI] Loading too fast, await animation.");
            
                var tween = GTweenExtensions.Tween(
                    () => (float)_progressBar.Value,
                    v => _progressBar.Value = v,
                    100f,
                    0.5f
                );
                tween.Play();
                await tween.AwaitCompleteOrKill(new CancellationToken());
            
                Logger.Log("[UI] Loading min animation finished.");
            }
            
            node.Modulate = node.Modulate with { A = 0f }; 
            GetTree().Root.CallDeferred(Node.MethodName.AddChild, node);
            
            node.Modulate = node.Modulate with { A = 0f };
            GTweenSequenceBuilder.New()
                .Append(this.TweenModulateAlpha(0f, 0.2f))
                .Append(node.TweenModulateAlpha(1f, 0.2f))
                .AppendCallback(() =>
                {
                    CallDeferred(Node.MethodName.QueueFree);
                })
                .Build()
                .Play();
        }

        var loader = new AcidLoader();
        
        loader.OnResourceLoad += path =>
        {
            _loadingLabel.Text = "正在加载" + path switch
            {
                "res://Scenes/World.tscn" => "世界场景",
                _ => "神秘资源"
            };
        };

        loader.OnProgressChanged += f =>
        {
            _progressBar.Value = f;
        };

        loader.OnResourceLoaded += (path, res) =>
        {
            switch (path)
            {
                case "res://Scenes/World.tscn":
                    WorldLoaded(res);
                    break;
            }
        };

        async void WorldLoaded(Resource res)
        {
            var scene = (PackedScene)res;
            loadedNode = scene.Instantiate<GameWorld>();
                    
            if (loadedNode == null)
            {
                Logger.LogError($"[BootSplash] Failed to load: {Path}");
                return;
            }
            
            ChangeScene(loadedNode);
        }

        loader.LoadResources(["res://Scenes/World.tscn"]);
    }
}
