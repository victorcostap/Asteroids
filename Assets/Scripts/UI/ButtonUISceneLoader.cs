using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUISceneLoader : MonoBehaviour
{
    public string sceneNewGame;
    public string sceneScores;
    public string sceneCredits;
    
    public void NewGame()
    {
        SceneManager.LoadScene(sceneNewGame);
    }

    public void Scores()
    {
        
    }

    public void Credits()
    {
        SceneManager.LoadScene(sceneCredits);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
