using UnityEngine;
using CodeUtils;

public class SampleMonoUpdater : MonoBehaviour
{
    void Start()
    {
        MonoUpdater.Add(() =>
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log(Time.time);
            }
        });
    }
}
