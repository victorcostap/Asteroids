using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ListScores : MonoBehaviour
{
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
