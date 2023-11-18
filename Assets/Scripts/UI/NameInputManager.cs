using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameInputManager : MonoBehaviour
{
    public TMP_InputField nameField;
    
    // Start is called before the first frame update
    private void Start()
    {
        nameField.text = "";
    }

    public void SubmitName()
    {
        var playerName = nameField.text;
        SavePlayerScore(playerName);
        SceneManager.LoadScene("TitleScreen");
    }

    private void SavePlayerScore(string playerName)
    {
        var score = ScoreManager.instance.score;
        // Save the player's name and score
        for (var i = 1; i <= ScoreManager.instance.maxScores; i++)
        {
            var currentScore = PlayerPrefs.GetInt("HighScore" + i, 0);

            if (score > currentScore)
            {
                var tempScore = PlayerPrefs.GetInt("HighScore" + i, 0);
                var tempName = PlayerPrefs.GetString("HighScoreName" + i, "");

                PlayerPrefs.SetInt("HighScore" + i, score);
                PlayerPrefs.SetString("HighScoreName" + i, playerName);

                score = tempScore;
                playerName = tempName;
            }
        }
    }
}
