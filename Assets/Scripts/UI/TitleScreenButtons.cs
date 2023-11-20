using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the buttons on the TitleScreen
/// </summary>
public class TitleScreenButtons : MonoBehaviour
{
    public string sceneNewGame;
    public string sceneScores;
    public string sceneCredits;
    
    /// <summary>
    /// Starts a new game
    /// </summary>
    public void NewGame()
    {
        ScoreManager.instance.ResetScore();
        SceneManager.LoadScene(sceneNewGame);
    }

    /// <summary>
    /// Displays the leaderboard
    /// </summary>
    public void Scores()
    {
        SceneManager.LoadScene(sceneScores);
    }
    
    /// <summary>
    /// Display the credits
    /// </summary>
    public void Credits()
    {
        SceneManager.LoadScene(sceneCredits);
    }

    /// <summary>
    /// Quit the game
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
