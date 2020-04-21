using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// RuntimeSet 基类
/// </summary>
namespace CodeUtils
{
    public abstract class RuntimeSetBase<T> : ScriptableObject
    {
        // 实例 RuntimeSet 列表对象
        List<T> items = new List<T>();
        // 返回 RuntimeSet 实例
        public List<T> All => items;

        // 加入
        public void Add(T t)
        {
            if (!items.Contains(t))
                items.Add(t);
        }

        // 移除
        public void Remove(T t)
        {
            if (items.Contains(t))
                items.Remove(t);
        }
    }
}
