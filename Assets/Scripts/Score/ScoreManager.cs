using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance = null;
    

    public int maxScores = 10;
    public int score = 0;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    
    public void ResetScore()
    {
        score = 0;
    }

    public bool IsHighScore()
    {
        return score > PlayerPrefs.GetInt("HighScore" + maxScores, 0);
    }
}
