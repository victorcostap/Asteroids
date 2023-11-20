using TMPro;
using UnityEngine;

/// <summary>
/// Singleton managing updating the score text of current game.
/// </summary>
public class ScoreTextManager : MonoBehaviour
{
    public static ScoreTextManager instance = null;
    /// <summary>
    /// Text to update with score
    /// </summary>
    public TMP_Text scoreText;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    
    private void Start()
    {
        UpdateText();
    }
    
    /// <summary>
    /// Add the specified points to the score and updates the text
    /// </summary>
    /// <param name="points">Points to add to the score</param>
    public void AddPoints(int points)
    {
        ScoreManager.instance.AddPoints(points);
        UpdateText();
    }
    
    /// <summary>
    /// Update text object with the score
    /// </summary>
    private void UpdateText()
    {
        scoreText.text = ScoreManager.instance.score.ToString();
    }
}
