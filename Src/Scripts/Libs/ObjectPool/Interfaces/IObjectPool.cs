namespace AcidWallStudio.ObjectPool;

public interface IObjectPool<T>
{
    /// <summary>
    /// 当前池中可用实例的总数
    /// </summary>
    public int CountInactive { get; }
    
    /// <summary>
    /// 删除所有池化实例。如果池包含销毁回调，那么将为池中的每个项目调用它
    /// </summary>
    public void Clear();

    /// <summary>
    /// 从池中取出实例
    /// </summary>
    public T Get();

    /// <summary>
    /// 将实例返回到池中
    /// </summary>
    public void Release(T obj);
}