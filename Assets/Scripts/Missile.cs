using System;
using UnityEngine;
using CodeUtils;


public class Missile : MonoBehaviour, IPool
{
    public float power = 10f;
    public float destoryTime = 2f;

    Rigidbody rigid;
    float timer;

    public UnityEngine.Object PoolKey { get; set; }
    public Pool Pool { get; set; }

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
            Pool.Recycle(PoolKey, this);
        }
    }
}
