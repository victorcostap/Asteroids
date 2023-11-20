using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Enable the player to write their name and submit it to the high scores along with their score.
/// </summary>
public class NameInputManager : MonoBehaviour
{
    /// <summary>
    /// Input field where to write the name
    /// </summary>
    public TMP_InputField nameField;
    
    // Start is called before the first frame update
    private void Start()
    {
        nameField.text = "";
    }
    
    /// <summary>
    /// Save player name and their score adn return to TitleScreen
    /// </summary>
    public void SubmitName()
    {
        var playerName = nameField.text;
        SavePlayerScore(playerName);
        SceneManager.LoadScene("TitleScreen");
    }

    /// <summary>
    /// Calculate player score position in leaderboard and assign it
    /// </summary>
    /// <param name="playerName">Player name that ahs achieved the high score</param>
    private void SavePlayerScore(string playerName)
    {
        var score = ScoreManager.instance.score;
        // Save the player's name and score
        for (var i = 1; i <= ScoreManager.instance.maxScores; i++)
        {
            var currentScore = PlayerPrefs.GetInt("HighScore" + i, 0);

            if (score <= currentScore) continue;
            var tempScore = PlayerPrefs.GetInt("HighScore" + i, 0);
            var tempName = PlayerPrefs.GetString("HighScoreName" + i, "");

            PlayerPrefs.SetInt("HighScore" + i, score);
            PlayerPrefs.SetString("HighScoreName" + i, playerName);

            score = tempScore;
            playerName = tempName;
        }
    }
}
