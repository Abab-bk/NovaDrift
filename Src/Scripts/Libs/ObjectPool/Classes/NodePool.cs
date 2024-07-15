using System;
using System.Collections.Generic;
using Godot;

namespace AcidWallStudio.ObjectPool;

/// <summary>
/// 用于存放 Node 的对象池
/// </summary>
/// <param name="createFunc">当池为空时创建新实例的 Func。大多数情况下，只是 () => new T()</param>
/// <param name="onGet">从池中取出实例时调用</param>
/// <param name="onRelease">当实例返回到池中时调用。可用于清理或禁用实例</param>
/// <param name="onDestroy">当由于池达到最大大小而无法将元素返回到池中时调用</param>
/// <param name="collectionCheck">当实例返回到池中时，将执行集合检查。如果实例已经在池中，则会抛出异常。</param>
/// <param name="defaultCapacity">创建堆栈时使用的默认容量</param>
/// <param name="maxCapacity">池的最大大小。当池达到最大大小时，返回到池中的任何其他实例将被忽略并可以被垃圾收集。这可以用来防止池增长到非常大的尺寸</param>
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
    /// 池已创建但当前正在使用且尚未返回的对象数量
    /// </summary>
    public int CountActive { get; private set; }
    
    /// <summary>
    /// 池中全部实例的数量，包含激活和未激活
    /// </summary>
    public int CountAll => _pool.Count;
    
    private readonly Stack<TNode> _pool = new Stack<TNode>();
    
    public void Init(Action<TNode> onInit = null)
    {
        for (int i = 0; i < defaultCapacity; i++)
        {
            var node = createFunc();
            _pool.Push(node);
            AddChild(node);
            onInit?.Invoke(node);
            onRelease(node);
        }
        
        CountInactive = defaultCapacity;
        CountActive = 0;
    }

    public void Clear()
    {
        foreach (var node in _pool)
        {
            node.QueueFree();
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

        if (CountInactive > 0)
        {
            // Logger.Log("[NodePool] Get an inactive object");
            return GetObj();
        }

        if (CountAll < maxCapacity)
        {
            // Logger.Log("[NodePool] Create a new object and push to pool");
            _pool.Push(createFunc());
            return GetObj();
        }
        
        Logger.Log("[NodePool] Create a new object");
        return createFunc();
    }

    public void Release(TNode obj)
    {
        if (collectionCheck && _pool.Contains(obj)) throw new Exception("对象已经在池中");
        if (_pool.Count >= maxCapacity)
        {
            onDestroy(obj);
            return;
        }

        onRelease(obj);
        _pool.Push(obj);
        CountInactive++;
    }
}