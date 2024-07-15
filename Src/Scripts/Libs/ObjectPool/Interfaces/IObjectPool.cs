namespace AcidWallStudio.ObjectPool;

public interface IObjectPool<T>
{
    /// <summary>
    /// The total number of inactive instances in the pool.
    /// 当前池中可用实例的总数
    /// </summary>
    public int CountInactive { get; }
    
    /// <summary>
    /// Deletes all active instances in the pool. If the pool contains a destroy callback,
    /// it will be called for each active instance.
    /// 删除所有池化实例。如果池包含销毁回调，那么将为池中的每个项目调用它
    /// </summary>
    public void Clear();

    /// <summary>
    /// Get an instance from the pool.
    /// 从池中取出实例
    /// </summary>
    public T Get();

    /// <summary>
    /// Release an instance back into the pool.
    /// 将实例返回到池中
    /// </summary>
    public void Release(T obj);
}