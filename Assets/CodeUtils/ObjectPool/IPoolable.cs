using System;

// 实现该接口，可以获取 pool 对象池的引用（通过 NotifyIPoolable 方法）
// 主要目的是便于对象自己控制回收的时间点
namespace CodeUtils
{
    public interface IPoolable
    {
        // 定义一个属性，实现类将继承该属性
        Pool Pool { get; set; }
    }
}
