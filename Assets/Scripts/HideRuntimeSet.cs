using UnityEngine;
using CodeUtils;

public class HideRuntimeSet : MonoBehaviour
{
    public RuntimeSet runtimeSet;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Hide();
        }
    }

    public void Hide()
    {
        runtimeSet.All[Random.Range(0, runtimeSet.All.Count)].SetActive(false);
    }
}
