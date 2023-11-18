using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Meteor : PooledObject
{
    private Collider _collider;
    private Rigidbody _rigidbody;

    public int valuePoints = 100;
    
    private void Start()
    {
        _collider = gameObject.GetComponent<Collider>();
        _rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }
    
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
                if (ScoreManager.instance.IsHighScore())
                {
                    SceneManager.LoadScene("AskPlayerName");
                }
                else
                {
                    SceneManager.LoadScene("TitleScreen");    
                }
                break;
        }
    }
}
