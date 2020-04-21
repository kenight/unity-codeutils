using UnityEngine;
using CodeUtils;

public class PlayerSfx : MonoBehaviour
{
    public AudioClip clip1;
    public AudioClip clip2;
    public Singleton audioSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            audioSource.Instance.GetComponent<AudioSource>().PlayOneShot(clip1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            audioSource.Instance.GetComponent<AudioSource>().PlayOneShot(clip2);
        }
    }
}
