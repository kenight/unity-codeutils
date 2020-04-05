using UnityEngine;

/* 静态对象池
特点：
1.固定对象池大小，且对象池中对象固定，只交换顺序
2.取出对象时不关心对象是否已被回收
3.不能用Destory删除取出的对象
 */
namespace CodeUtils
{
    [CreateAssetMenu(menuName = "Scriptable/Pool/Staic Pool")]
    public class StaticPool : Pool
    {
        // 对象池容量
        public int capacity;

        // 获取对象
        public override GameObject Get()
        {
            GameObject obj;
            // 未达容量时，持续实例化
            if (pool.Count < capacity)
            {
                obj = Instantiate(prefab);
                pool.Enqueue(obj);
                NotifyIPoolable(obj);
                return obj;
            }
            // 到达容量上限后，不再实例化，且大小不再改变
            // 开始从池中取对象
            obj = pool.Dequeue();
            // 立即重新加入队列（尾）
            pool.Enqueue(obj);
            // 激活对象
            obj.SetActive(true);
            return obj;
        }

        // 回收对象（非必要）
        // 慎用定时函数回收对象，会造成混乱
        public override void Reuse(GameObject obj)
        {
            // 为保证对象池大小固定与依赖，不能Destory对象
            obj.SetActive(false);
        }
    }
}
