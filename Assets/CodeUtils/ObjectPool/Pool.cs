using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对象池基类
/// </summary>
namespace CodeUtils
{
    public abstract class Pool : ScriptableObject
    {
        // 放入对象池中的游戏对象
        public GameObject prefab;
        // 实例化对象池队列
        protected Queue<GameObject> pool = new Queue<GameObject>();
        // 返回对象池实例
        public Queue<GameObject> All => pool;

        // 初始化对象池，用于覆盖放入对象池中的对象
        public void Init(GameObject prefab) => (this.prefab) = (prefab);

        // 获取对象
        public abstract GameObject Get();

        // 回收对象
        public abstract void Reuse(GameObject obj);

        // 为 IPoolable 接口的实现类提供 pool 的引用
        protected void NotifyIPoolable(GameObject obj)
        {
            var iPool = obj.GetComponent<IPoolable>();
            if (iPool != null)
                iPool.Pool = this;
        }
    }
}
