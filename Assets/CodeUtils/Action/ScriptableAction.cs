using UnityEngine;

namespace CodeUtils
{
    public abstract class ScriptableAction : ScriptableObject
    {
        public abstract void Invoke(GameObject obj);
    }
}
