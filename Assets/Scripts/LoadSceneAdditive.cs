using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAdditive : MonoBehaviour
{
    public string sceneName;

    void Start()
    {
        if (SceneManager.GetSceneByName(sceneName).isLoaded)
            return;
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }
}
