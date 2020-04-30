using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 动态对象池
/// 特点：
/// 1.对象池中对象数量不固定
/// 2.必须依赖 Recycle 回收对象，如果没有回收对象则一直实例化新对象
/// </summary>
namespace CodeUtils
{
    [CreateAssetMenu(menuName = "Scriptable/Pool System/Pool")]
    public class Pool : ScriptableObject
    {
        Dictionary<Object, Queue<Object>> pool = new Dictionary<Object, Queue<Object>>();

        // 这里使用了与 Object.Instantiate 同样的泛型实现方式
        // 传入什么类型就返回什么类型
        public T Get<T>(T prefab) where T : Object
        {
            Object obj;
            Queue<Object> queue;
            // 是否为 prefab 建立有对象池
            if (pool.TryGetValue(prefab, out queue))
            {
                // 有对象池，且有可复用的对象
                if (queue.Count > 0)
                {
                    obj = queue.Dequeue();
                    GetGameObject(obj).SetActive(true);
                }
                // 有对象池，但无可用对象
                else
                    obj = NewInstance(prefab);
            }
            // 未建立对象池
            else
            {
                // 初始化一个空的对象池，用作后期回收
                pool.Add(prefab, new Queue<Object>());
                obj = NewInstance(prefab);
            }
            return obj as T;
        }

        // 重点依赖该方法回收对象，否则对象池形同虚设
        // 第一个参数为回收对象所在对象池Key值
        // 回收对象的类型与初始化时的类型一定要一致
        public void Recycle(Object key, Object recycleObj)
        {
            if (key.GetType() != recycleObj.GetType())
            {
                Debug.LogError("Recycle object failed : Type not matched", recycleObj);
                return;
            }
            Queue<Object> queue;
            if (pool.TryGetValue(key, out queue))
                queue.Enqueue(recycleObj);
            GetGameObject(recycleObj).SetActive(false);
        }

        // 清空所有对象池
        public void Clear() => pool.Clear();

        Object NewInstance(Object prefab)
        {
            var obj = Instantiate(prefab);
            var i = GetGameObject(obj).GetComponent<IPool>();
            if (i != null)
            {
                i.Pool = this;
                i.PoolKey = prefab;
            }
            return obj;
        }

        GameObject GetGameObject(Object obj)
        {
            if (obj is Component comp)
                return comp.gameObject;
            return obj as GameObject;
        }
    }
}
