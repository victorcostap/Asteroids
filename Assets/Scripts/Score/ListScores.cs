using TMPro;
using UnityEngine;

/// <summary>
/// Updates a text with the list of the high scores
/// </summary>
public class ListScores : MonoBehaviour
{
    /// <summary>
    /// Text to update
    /// </summary>
    public TMP_Text text;
    
    // Start is called before the first frame update
    private void Start()
    {
        text.text = "";
        for (var i = 1; i <= ScoreManager.instance.maxScores; ++i)
        {
            var tempScore = PlayerPrefs.GetInt("HighScore" + i, 0);
            var tempName = PlayerPrefs.GetString("HighScoreName" + i, "");

            if (tempScore != 0)
            {
                text.text += i + " - " + tempName + " : " + tempScore + "\n";
            }
            else
            {
                text.text += i + " - XXXXX : 0\n";
            }
        }
    }
}
