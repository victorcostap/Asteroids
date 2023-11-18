using TMPro;
using UnityEngine;


public class ScoreTextManager : MonoBehaviour
{
    public static ScoreTextManager instance = null;
    public TMP_Text scoreText;
    
    private void Awake()
    {
        instance = this;
    }
    
    private void Start()
    {
        UpdateText();
    }
    
    public void AddPoints(int points)
    {
        ScoreManager.instance.score += points;
        UpdateText();
    }
    
    private void UpdateText()
    {
        scoreText.text = ScoreManager.instance.score.ToString();
    }
}
