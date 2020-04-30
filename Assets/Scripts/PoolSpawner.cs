using System.Collections;
using UnityEngine;
using CodeUtils;

public class PoolSpawner : MonoBehaviour
{
    public float upForce = 20f;
    public float sideForce = 5f;
    public float rate = 1f;
    public Pool pool;
    public Rigidbody prefab1;
    public Rigidbody prefab2;
    public Missile missile;

    void Start()
    {
        // InvokeRepeating("Launch", .5f, rate);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Launch(prefab1);

        if (Input.GetKeyDown(KeyCode.D))
            Launch(prefab2);

        if (Input.GetKeyDown(KeyCode.F))
        {
            var m = pool.Get(missile);
            m.transform.position = transform.position * 5f;
        }
    }

    void Launch(Rigidbody obj)
    {
        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = Random.Range(upForce / 2, upForce);
        float zForce = Random.Range(-sideForce, sideForce);

        var rb = pool.Get(obj);

        rb.position = transform.position + new Vector3(Random.value * 2, 0, Random.value * 2);
        rb.velocity = new Vector3(xForce, yForce, zForce);
        StartCoroutine(ReuseObject(obj, rb));
    }

    // 回收该对象
    IEnumerator ReuseObject(Rigidbody key, Rigidbody obj)
    {
        yield return new WaitForSeconds(5f);
        pool.Recycle(key, obj);
    }
}
