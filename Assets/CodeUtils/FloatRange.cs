using UnityEngine;

namespace CodeUtils
{
    [System.Serializable]
    public struct FloatRange
    {
        public float min, max;
        public float RandomValue => Random.Range(min, max);
    }
}
