using UnityEngine;
using CodeUtils;

public class Player : MonoBehaviour
{
    public FloatReference hp;
    public GameEvent onPlayerDamaged;

    void Start()
    {
        hp.Value = 100;
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Translate(new Vector3(input.x, input.y, 0) * Time.deltaTime * 5);
    }

    void OnTriggerEnter(Collider other)
    {
        TakeDamage();
    }

    void TakeDamage()
    {
        hp.Value -= 10;
        onPlayerDamaged?.Raise();
    }
}
