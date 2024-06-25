using System;
using Godot;
using Array = Godot.Collections.Array;

namespace AcidWallStudio.AcidUtilities;

public class AcidLoader
{
    public event Action<float> OnProgressChanged;
    public event Action<string> OnResourceLoad;
    public event Action<string, Resource> OnResourceLoaded; 
    public event Action OnAllLoaded;
    
    public void LoadResources(string[] paths)
    {
        foreach (var path in paths)
        {
            ResourceLoader.LoadThreadedRequest(path);
            
            OnResourceLoad?.Invoke(path);
            Array progress = [];

            while (true)
            {
                var loadStatus = ResourceLoader.LoadThreadedGetStatus(path, progress);
                switch (loadStatus)
                {
                    case ResourceLoader.ThreadLoadStatus.Loaded:
                        OnProgressChanged?.Invoke((float)progress[0]);
                        break;
                    case ResourceLoader.ThreadLoadStatus.InProgress:
                        OnProgressChanged?.Invoke((float)progress[0]);
                        continue;
                    case ResourceLoader.ThreadLoadStatus.Failed:
                        Logger.LogError($"[AcidLoader] Failed to load: {path}");
                        break;
                    case ResourceLoader.ThreadLoadStatus.InvalidResource:
                        Logger.LogError($"[AcidLoader] Invalid resource: {path}");
                        break;
                }
                break;
            }
            
            OnResourceLoaded?.Invoke(path, ResourceLoader.LoadThreadedGet(path));
        }
        
        OnAllLoaded?.Invoke();
    }
}