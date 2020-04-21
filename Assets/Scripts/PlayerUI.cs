using UnityEngine;
using UnityEngine.UI;
using CodeUtils;

public class PlayerUI : MonoBehaviour
{
    public Image hpImage;
    public FloatVariable hp;
    public bool debug;

    void Start()
    {
        MonoUpdater.Add(() =>
        {
            ChangeHP();
        }, debug);
    }

    public void ChangeHP()
    {
        hpImage.fillAmount = hp.Value / 100;
    }
}
