﻿using CodeUtils;
using UnityEngine;

namespace CodeUtils
{
    [CreateAssetMenu(menuName = "Scriptable/Action/Spawn")]
    public class SpawnAction : ScriptableAction
    {
        public GameObject[] prefabs;
        public bool autoDestroy;
        public float destroyDelay;

        public override void Invoke(GameObject obj)
        {
            foreach (var p in prefabs)
            {
                GameObject clonePrefab = Instantiate(p, obj.transform.position, obj.transform.rotation);
                if (autoDestroy) Destroy(clonePrefab, destroyDelay);
            }
        }
    }
}
