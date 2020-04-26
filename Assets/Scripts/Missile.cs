using System;
using UnityEngine;
using CodeUtils;


public class Missile : MonoBehaviour, IPoolSystem
{
    public float power = 10f;
    public float destoryTime = 2f;

    Rigidbody rigid;
    float timer;

    public PoolSystem poolSystem { get; set; }
    public GameObject poolKey { get; set; }

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        rigid.velocity = transform.forward * power;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > destoryTime)
        {
            timer -= destoryTime;
            poolSystem.Recycle(poolKey, gameObject);
        }
    }
}
