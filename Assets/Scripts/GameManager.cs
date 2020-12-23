using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// this script is responsible for all interaction with UI Element
/// 
/// @author : Martin Christian Solihin
/// </summary>

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText, numberCakeToCollect;
    public Image health_1,  health_2, health_3;
    public int score, health = 3, numberCake;

    public void StartGame() {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void RestartGame() {
        score = 0;
        health = 3;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackMainMenu() {
        score = 0;
        health = 3;

        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void GameOver() {
        // pause game
        // pop up die -> panel
    }

    public int GetScore() {
        return score;
    }

    public void SetScore(int newScore) {
        score = newScore;
        scoreText.text = "Score : " + newScore.ToString();
    }

    public int GetHealth() {
        return health;
    }

    public void SetHealth(int newHealth) {
        health = newHealth;
        if (health == 3) {
            health_1.enabled = true;
            health_2.enabled = true;
            health_3.enabled = true;
        } else if (health == 2) {
            health_1.enabled = false;
            health_2.enabled = true;
            health_3.enabled = true;
        } else if (health == 1) {
            health_1.enabled = false;
            health_2.enabled = false;
            health_3.enabled = true;
        } else if (health == 0) {
            health_1.enabled = false;
            health_2.enabled = false;
            health_3.enabled = false;
        }
    }

    public int GetNumberCake() {
        return numberCake;
    }

    public void SetNumberCake(int cake) {
        numberCake = cake;
        numberCakeToCollect.text = "Cake Left : " + numberCake.ToString();
    }

    private void Update() {
        if (numberCake == 0) {
            Debug.Log("You WIN");
        }
    }
}
