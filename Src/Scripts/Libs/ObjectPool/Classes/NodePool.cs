using System;
using System.Collections.Generic;
using Godot;

namespace AcidWallStudio.ObjectPool;

/// <summary>
/// An Object pool for storing Node.
/// </summary>
/// <param name="createFunc">A Func to create an instance when the pool is empty. e.g: () => new TNode()</param>
/// <param name="onGet">Called when an instance is taken from the pool.</param>
/// <param name="onRelease">Called when an instance is returned to the pool. Can be used for cleanup.</param>
/// <param name="onDestroy">Called when an instance can't return due to the pool reaching max size.</param>
/// <param name="collectionCheck">When an instance is returned to the pool, a collection check is performed. If the instance is already in the pool, an exception will be thrown.</param>
/// <param name="defaultCapacity">The default capacity used when creating the pool.</param>
/// <param name="maxCapacity">The maximum size of the pool.</param>
/// <typeparam name="TNode"></typeparam>
public partial class NodePool<TNode>(
    Func<TNode> createFunc,
    Action<TNode> onGet,
    Action<TNode> onRelease,
    Action<TNode> onDestroy,
    bool collectionCheck,
    int defaultCapacity,
    int maxCapacity
    ) : Node, IObjectPool<TNode> where TNode : Node
{
    public int CountInactive { get; private set; }
    
    /// <summary>
    /// The total number of active instances in the pool.
    /// </summary>
    public int CountActive { get; private set; }
    
    /// <summary>
    /// The total number of instances in the pool. Includes both active and inactive instances.
    /// </summary>
    public int CountAll => _pool.Count;
    
    private readonly Stack<TNode> _pool = new Stack<TNode>();

    private Action<TNode> _onInit;
    
    /// <summary>
    /// Init pool
    /// </summary>
    /// <param name="onInit">Called when an instance is init.</param>
    public void Init(Action<TNode> onInit = null)
    {
        _onInit = onInit;
        
        for (int i = 0; i < defaultCapacity; i++)
        {
            var node = createFunc();
            _pool.Push(node);
            AddChild(node);
            _onInit?.Invoke(node);
            onRelease(node);
        }
        
        CountInactive = defaultCapacity;
        CountActive = 0;
    }

    public void Clear()
    {
        foreach (var node in _pool)
        {
            onDestroy(node);
        }
        _pool.Clear();
        CountInactive = 0;
        CountActive = 0;
    }

    public TNode Get()
    {
        TNode GetObj()
        {
            var node = _pool.Pop();
            onGet(node);
            CountInactive--;
            CountActive++;
            return node;
        }

        if (CountInactive > 0) return GetObj();

        if (CountAll < maxCapacity)
        {
            var node = createFunc();
            _pool.Push(node);
            AddChild(node);
            _onInit?.Invoke(node);
            return GetObj();
        }

        var obj = createFunc();
        AddChild(obj);
        _onInit?.Invoke(obj);
        return obj;
    }

    public void Release(TNode obj)
    {
        if (OS.HasFeature("editor") && collectionCheck && _pool.Contains(obj))
            throw new Exception("Object is already in the pool.");
        
        if (_pool.Count >= maxCapacity)
        {
            onDestroy(obj);
            return;
        }

        onRelease(obj);
        _pool.Push(obj);
        CountActive--;
        CountInactive++;
    }
}