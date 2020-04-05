using UnityEngine;
using CodeUtils;

public class DynamicPoolSpawner : MonoBehaviour
{
    public Pool pool;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
    }

    void FixedUpdate()
    {
        // Launch();
    }

    void Launch()
    {
        var missile = pool.Get().GetComponent<Missile>();
        missile.transform.position = transform.position;
    }
}
