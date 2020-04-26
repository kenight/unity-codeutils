using UnityEngine;
using CodeUtils;

public class FixedPoolSpawner : MonoBehaviour
{
    public FixedPoolSystem fixedPoolSystem;
    public GameObject prefab1;
    public GameObject prefab2;

    void Start()
    {
        fixedPoolSystem.InitPool(prefab1, 5);
        fixedPoolSystem.InitPool(prefab2, 10);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            var go = fixedPoolSystem.Get(prefab1);
            go.transform.position = transform.position;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            var rb = fixedPoolSystem.Get<Rigidbody>(prefab2);
            rb.position = transform.position;
        }
    }
}
