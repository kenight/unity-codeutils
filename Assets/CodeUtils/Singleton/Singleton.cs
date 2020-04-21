using UnityEngine;

namespace CodeUtils
{
    [CreateAssetMenu(menuName = "Scriptable/Singleton", fileName = "New Singleton")]
    public class Singleton : SingletonBase<Component> { }
}
