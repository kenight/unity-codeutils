using UnityEngine;
using CodeUtils;

public class FixedPoolSpawner : MonoBehaviour
{
    public PoolFixed pool;
    public GameObject prefab1;
    public Rigidbody prefab2;

    void Start()
    {
        pool.InitPool(prefab1, 5);
        pool.InitPool(prefab2, 10);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            var go = pool.Get(prefab1);
            go.transform.position = transform.position;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            var rb = pool.Get(prefab2);
            rb.position = transform.position;
        }
    }
}
