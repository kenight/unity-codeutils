using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 动态对象池
/// 特点：
/// 1.对象池中对象数量不固定
/// 2.依赖 Recycle 回收对象，如果没有回收对象则一直实例化新对象
/// </summary>
namespace CodeUtils
{
    [CreateAssetMenu(menuName = "Scriptable/Pool System/Pool")]
    public class PoolSystem : ScriptableObject
    {
        Dictionary<GameObject, Queue<GameObject>> pool = new Dictionary<GameObject, Queue<GameObject>>();

        public GameObject Get(GameObject prefab)
        {
            GameObject obj;
            Queue<GameObject> queue;
            // 是否为 prefab 建立有对象池
            if (pool.TryGetValue(prefab, out queue))
            {
                // 有对象池，且有可复用的对象
                if (queue.Count > 0)
                {
                    obj = queue.Dequeue();
                    obj.SetActive(true);
                }
                // 有对象池，但无可用对象
                else
                    obj = NewInstance(prefab);
            }
            // 未建立对象池
            else
            {
                // 新建空的对象池，用作后期回收
                pool.Add(prefab, new Queue<GameObject>());
                obj = NewInstance(prefab);
            }
            return obj;
        }

        // 直接返回组件类型
        public T Get<T>(GameObject prefab) where T : Component
        {
            return Get(prefab).GetComponent<T>();
        }

        // 回收对象，第一个参数为回收对象所在对象池的 Dictionary Key
        public void Recycle(GameObject key, GameObject obj)
        {
            Queue<GameObject> queue;
            if (pool.TryGetValue(key, out queue))
                queue.Enqueue(obj);
            obj.SetActive(false);
        }

        // 生成新对象，绑定接口传递消息
        GameObject NewInstance(GameObject prefab)
        {
            var obj = Instantiate(prefab);
            var i = obj.GetComponent<IPoolSystem>();
            if (i != null)
            {
                i.poolSystem = this;
                i.poolKey = prefab;
            }
            return obj;
        }
    }
}
