using System.Collections;
using UnityEngine;
using CodeUtils;

public class StaticPoolSpawner : MonoBehaviour
{
    public float upForce = 20f;
    public float sideForce = 5f;
    public float rate = 1f;
    public Pool pool;

    void Start()
    {
        InvokeRepeating("Create", .5f, rate);
    }

    void Create()
    {
        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = Random.Range(upForce / 2, upForce);
        float zForce = Random.Range(-sideForce, sideForce);

        GameObject g = pool.Get();
        g.transform.position = transform.position + new Vector3(Random.value * 2, 0, Random.value * 2);
        g.GetComponent<Rigidbody>().velocity = new Vector3(xForce, yForce, zForce);
    }
}
