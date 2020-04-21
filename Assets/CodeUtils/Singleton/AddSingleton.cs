using UnityEngine;

namespace CodeUtils
{
    public class AddSingleton : MonoBehaviour
    {
        public Singleton singleton;

        void OnEnable()
        {
            singleton.Create(this);
        }

        void OnDisable()
        {
            singleton.Remove();
        }
    }
}
