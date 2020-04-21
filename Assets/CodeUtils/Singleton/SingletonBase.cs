using UnityEngine;

/// <summary>
/// Singleton 基类
/// </summary>
namespace CodeUtils
{
    public abstract class SingletonBase<T> : ScriptableObject where T : Component
    {
        public T Instance { get; private set; }

        public void Create(T t)
        {
            if (Instance != null)
            {
                Debug.LogWarning("There are more than one components attached to this sinagleton.", t.gameObject);
                return;
            }
            Instance = t;
        }

        public void Remove()
        {
            Instance = null;
        }
    }
}