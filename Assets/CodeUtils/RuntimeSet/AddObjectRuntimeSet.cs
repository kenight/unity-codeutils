using UnityEngine;

namespace CodeUtils
{
    public class AddObjectRuntimeSet : MonoBehaviour
    {
        public ObjectRuntimeSet runtimeSet;

        void OnEnable()
        {
            runtimeSet.Add(this.gameObject);
        }

        void OnDisable()
        {
            runtimeSet.Remove(this.gameObject);
        }
    }
}
