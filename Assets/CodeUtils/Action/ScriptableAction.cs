using UnityEngine;

/// <summary>
/// 使用 ScriptableObject 保存重复性的代码片段
/// </summary>
namespace CodeUtils
{
    public abstract class ScriptableAction : ScriptableObject
    {
        // 通过参数建立与场景对象的联系
        public abstract void Invoke(GameObject obj);
    }
}
