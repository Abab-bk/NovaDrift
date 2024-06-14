using System.Threading;
using Godot;
using GTweens.Builders;
using GTweens.Extensions;
using GTweensGodot.Extensions;
using Array = Godot.Collections.Array;
using Timer = Godot.Timer;

namespace NovaDrift.Scripts;

public partial class BootSplash : Control
{
    [GetNode("%ProgressBar")] private ProgressBar _progressBar;
    [GetNode("AnimationPlayer")] private AnimationPlayer _animationPlayer;
    [GetNode("MinLoadingTimer")] private Timer _minLoadingTimer;
    
    private const string Path = "res://Scenes/World.tscn";
    
    public override void _Ready()
    {
        if (OS.GetEnvironment("ShowStartMenu") != "true")
        {
            GetTree().ChangeSceneToFile(Path);
            return;
        }
        
        _progressBar.Value = 0;
        _animationPlayer.AnimationFinished += _ =>
        {
            _minLoadingTimer.Start();
            Loading();
        };
        _animationPlayer.Play("Run");
    }
    
    private async void Loading()
    {
        ResourceLoader.LoadThreadedRequest(Path);

        GameWorld loadedNode = null;
            
        while (true)
        {
            Array progress = [];
            var loadStatus = ResourceLoader.LoadThreadedGetStatus(Path, progress);
            switch (loadStatus)
            {
                case ResourceLoader.ThreadLoadStatus.Loaded:
                    var scene = (PackedScene)ResourceLoader.LoadThreadedGet(Path);
                    loadedNode = scene.Instantiate() as GameWorld;
                    break;
                case ResourceLoader.ThreadLoadStatus.InProgress:
                    _progressBar.Value = (float)progress[0];
                    continue;
                case ResourceLoader.ThreadLoadStatus.Failed:
                    Logger.LogError($"[BootSplash] Failed to load: {Path}");
                    break;
                case ResourceLoader.ThreadLoadStatus.InvalidResource:
                    Logger.LogError($"[BootSplash] Invalid resource: {Path}");
                    break;
            }
            break;
        }

        if (loadedNode == null)
        {
            Logger.LogError($"[BootSplash] Failed to load: {Path}");
            return;
        }

        if (!_minLoadingTimer.IsStopped())
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

        GetTree().Root.CallDeferred(Node.MethodName.AddChild, loadedNode);
        loadedNode.Modulate = loadedNode.Modulate with { A = 0f };
        GTweenSequenceBuilder.New()
            .Append(this.TweenModulateAlpha(0f, 0.2f))
            .Append(loadedNode.TweenModulateAlpha(1f, 0.2f))
            .AppendCallback(() =>
            {
                CallDeferred(Node.MethodName.QueueFree);
            })
            .Build()
            .Play();
    }
}
