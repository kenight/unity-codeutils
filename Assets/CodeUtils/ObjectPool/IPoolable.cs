using System;

/// <summary>
/// 对象池通知接口
/// 实现该接口的类可以获取该对象池的引用（通过 NotifyIPoolable 方法）
/// 主要目的是便于对象自己控制回收的时间点
/// </summary>
namespace CodeUtils
{
    public interface IPoolable
    {
        // 通过该属性获取对象池的引用
        Pool Pool { get; set; }
    }
}
