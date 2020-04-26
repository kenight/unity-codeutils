using UnityEngine;

/// <summary>
/// 动态对象池
/// 特点：
/// 1.对象池大小不固定，取一个少一个，回收一个多一个，数量动态变化
/// 2.只能取出已回收对象，否则只能实例化新对象，如果没有回收对象则一直实例化
/// 3.可以使用Destory删除取出的对象，唯一影响可回收对象减少了
/// 4.使用动态对象池，需要控制好生成与回收的速率，生成速率太快将导致不断实例化新对象
/// </summary>
namespace CodeUtils
{
    [CreateAssetMenu(menuName = "Scriptable/Pool/Dynamic Pool")]
    public class DynamicPool : Pool
    {
        // 获取对象
        public override GameObject Get()
        {
            GameObject obj;
            // 对象池中无可用对象，则实例化
            if (pool.Count < 1)
            {
                obj = Instantiate(prefab);
                NotifyIPoolable(obj);
                return obj;
            }
            // 从对象池中取对象
            obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        // 回收对象（必须使用该方法回收对象）
        public override void Reuse(GameObject obj)
        {
            pool.Enqueue(obj);
            obj.SetActive(false);
        }
    }
}
