using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this script is responsible for all interaction with the player
/// 
/// @author : Martin Christian Solihin
/// </summary>

public class PlayerManagement : MonoBehaviour
{
    public GameManager gameManager;
    private int score, health, cake;
    public bool isDead;

    private void Start() {
        score = gameManager.GetScore();
        health = gameManager.GetHealth();

        cake = gameManager.GetNumberCake();
    }

    public void AddScore() {
        score++;

        if (score % 10 == 0) {
            AddOneLife();
        }

        gameManager.SetScore(score);
    }

    public void MinusCake() {
        cake--;

        gameManager.SetNumberCake(cake);
    }

    public void LoseOneLife() {
        health--;

        if (health == -1) {
            isDead = true;
            Destroy(gameObject);
            gameManager.GameOver();
        } else {
            gameManager.SetHealth(health);
        }
    }

    public void AddOneLife() {
        if (health < 3) {
            health++;
            gameManager.SetHealth(health);    
        } else 
            Debug.Log("Life is full");
    }
}