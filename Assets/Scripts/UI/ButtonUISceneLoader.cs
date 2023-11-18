using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUISceneLoader : MonoBehaviour
{
    public string sceneNewGame;
    public string sceneScores;
    public string sceneCredits;
    
    public void NewGame()
    {
        ScoreManager.instance.ResetScore();
        SceneManager.LoadScene(sceneNewGame);
    }

    public void Scores()
    {
        SceneManager.LoadScene(sceneScores);
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
