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
    [CreateAssetMenu(menuName = "Scriptable/Pool System/Pool Fixed")]
    public class PoolFixed : ScriptableObject
    {
        Dictionary<Object, Queue<Object>> pool = new Dictionary<Object, Queue<Object>>();

        public void InitPool(Object prefab, int size)
        {
            if (pool.ContainsKey(prefab))
                return;
            Queue<Object> queue = new Queue<Object>();
            for (int i = 0; i < size; i++)
            {
                var obj = Instantiate(prefab);
                GetGameObject(obj).SetActive(false);
                queue.Enqueue(obj);
            }
            pool.Add(prefab, queue);
        }

        public T Get<T>(T prefab) where T : Object
        {
            Object obj;
            Queue<Object> queue;
            if (pool.TryGetValue(prefab, out queue))
            {
                if (queue.Count > 0)
                {
                    obj = queue.Dequeue();
                    queue.Enqueue(obj);
                    GetGameObject(obj).SetActive(true);
                    return obj as T;
                }
            }
            Debug.LogError("No pool was init with this prefab");
            return null;
        }

        public void Clear() => pool.Clear();

        GameObject GetGameObject(Object obj)
        {
            if (obj is Component comp)
                return comp.gameObject;
            return obj as GameObject;
        }
    }
}
