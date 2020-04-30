using UnityEngine;

/// <summary>
/// 对象池通知接口
/// 实现该接口的类可以获取对象池类与所在对象池Key值的引用
/// 主要目的是便于对象自己控制回收的时间点
/// </summary>
namespace CodeUtils
{
    public interface IPool
    {
        Pool Pool { get; set; } // 传递对象池类的引用
        Object PoolKey { get; set; } // 传递所在对象池Key值
    }
}
