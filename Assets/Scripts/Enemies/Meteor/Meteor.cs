using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Meteor object. Handles collisions with Bullets and with the Player.
/// </summary>
public class Meteor : PooledObject
{
    /// <summary>
    /// Numeric value to sum to the score when is destroyed
    /// </summary>
    public int valuePoints = 100;
    
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Bullet":
                ScoreTextManager.instance.AddPoints(valuePoints);
                gameObject.SetActive(false);
                other.gameObject.SetActive(false);
                break;
            case "Player":
                // If there is a high score, ask for player name, if not, return to title
                SceneManager.LoadScene(ScoreManager.instance.IsHighScore() ? "AskPlayerName" : "TitleScreen");
                break;
        }
    }
}
