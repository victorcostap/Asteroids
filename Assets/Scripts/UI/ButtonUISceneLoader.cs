using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUISceneLoader : MonoBehaviour
{
    public string sceneToLoad;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
