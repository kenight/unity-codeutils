using UnityEngine;

namespace CodeUtils
{
    public class AddRuntimeSet : MonoBehaviour
    {
        public RuntimeSet runtimeSet;

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