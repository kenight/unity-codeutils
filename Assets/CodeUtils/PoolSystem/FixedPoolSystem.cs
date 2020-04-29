using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 固定数量对象池
/// 特点：
/// 1.对象池中对象数量固定
/// 2.必须调用初始化方法初始对象池
/// 3.对象使用隐藏来回收对象，不能删除对象，否则失去依赖
/// </summary>
namespace CodeUtils
{
    [CreateAssetMenu(menuName = "Scriptable/Pool System/Fixed Pool")]
    public class FixedPoolSystem : ScriptableObject
    {
        Dictionary<GameObject, Queue<GameObject>> pool = new Dictionary<GameObject, Queue<GameObject>>();

        public void InitPool(GameObject prefab, int size)
        {
            if (pool.ContainsKey(prefab))
                return;
            Queue<GameObject> queue = new Queue<GameObject>();
            for (int i = 0; i < size; i++)
            {
                var obj = Instantiate(prefab);
                obj.SetActive(false);
                queue.Enqueue(obj);
            }
            pool.Add(prefab, queue);
        }

        public GameObject Get(GameObject prefab)
        {
            GameObject obj;
            Queue<GameObject> queue;
            if (pool.TryGetValue(prefab, out queue))
            {
                if (queue.Count > 0)
                {
                    obj = queue.Dequeue();
                    queue.Enqueue(obj);
                    obj.SetActive(true);
                    return obj;
                }
            }
            Debug.LogError("No pool was init with this prefab");
            return null;
        }

        public T Get<T>(GameObject prefab) where T : Component
        {
            return Get(prefab).GetComponent<T>();
        }

        // 清空对象池，特别是重新加载场景等时需要清空
        public void Clear()
        {
            pool.Clear();
        }
    }
}
