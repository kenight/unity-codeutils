using UnityEngine;

/// <summary>
/// 对象池通知接口
/// 实现该接口的类可以获取该类所在对象池的引用（如果该类并没有对象池则无用）
/// 主要目的是便于对象自己控制回收的时间点
/// </summary>
namespace CodeUtils
{
    public interface IPoolSystem
    {
        // 取得 PoolSystem 的引用
        PoolSystem poolSystem { get; set; }
        // 取得该对象所在对象池的 KEY 值 (Dictionary key)
        GameObject poolKey { get; set; }
    }
}
