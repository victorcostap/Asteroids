using UnityEngine;

/// <summary>
/// Singleton handling the score tracking
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance = null;
    
    /// <summary>
    /// Maximum number of scores in the leaderboard
    /// </summary>
    public int maxScores = 10;
    /// <summary>
    /// Score of current game
    /// </summary>
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
    
    /// <summary>
    /// Add the specified points to the score
    /// </summary>
    /// <param name="points">Points to add to the score</param>
    public void AddPoints(int points)
    {
        score += points;
    }
    
    /// <summary>
    /// Resets score to 0
    /// </summary>
    public void ResetScore()
    {
        score = 0;
    }

    /// <summary>
    /// Check if current game score is a high score
    /// </summary>
    /// <returns>true if it is high score, false if not</returns>
    public bool IsHighScore()
    {
        return score > PlayerPrefs.GetInt("HighScore" + maxScores, 0);
    }
}
