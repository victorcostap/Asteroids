using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TMP_Text scoreText;
    
    public int score;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        UpdateText();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateText()
    {
        scoreText.text = score.ToString();
    }
    
    public void AddPoints(int points)
    {
        score += points;
        UpdateText();
    }
}
