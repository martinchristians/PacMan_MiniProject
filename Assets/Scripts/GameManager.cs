using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.EventSystems;

/// <summary>
/// this script is responsible for all UI Element interaction on game
/// 
/// @author : Martin Christian Solihin
/// </summary>

public enum DIFFICULTY {
    ONE,
    TWO,
    THREE
}

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText, numberCakeToCollect;
    public Image health_1,  health_2, health_3;
    public int score, health = 3, numberCake, sizeBoard;
    public AudioMixer audioMixer;
    public GameObject mainPanel, winPanel, losePanel;
    public Transform cam;
    private DIFFICULTY difficulty = DIFFICULTY.THREE;
    public LevelGenerator difficulty1, difficulty2, difficulty3 ;

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

    public void GameOver() {
        mainPanel.SetActive(false);
        losePanel.SetActive(true);
    }

    public void GameWin() {
        mainPanel.SetActive(false);
        winPanel.SetActive(true);
    }

    public void SetVolume(float vol) {
        audioMixer.SetFloat("mainVolume", vol);
    }

    public void Pause() {
        Time.timeScale = 0;
    }

    public void Resume() {
        Time.timeScale = 1;
    }

// NOT YET WORKING
    public void Difficulty(Button button) {

        if (button.name == "Button 1") {
            difficulty = DIFFICULTY.ONE;
        } else if (button.name == "Button 2") {
            difficulty = DIFFICULTY.TWO;
        } else if (button.name == "Button 3") {
            difficulty = DIFFICULTY.THREE;
        }

        ColorBlock colors = button.colors;
        colors.normalColor = Color.white;
        button.colors = colors;

        switch(difficulty){
            case DIFFICULTY.ONE:
                Debug.Log("difficultiy One");
                cam.transform.position = new Vector3(-22.5f, 47.5f, -50);

                difficulty1.difficultyOne();
                break;

            case DIFFICULTY.TWO:
                Debug.Log("difficultiy Two");
                cam.transform.position = new Vector3(-14, 68, -50);

                difficulty2.difficultyTwo();
                break;

            case DIFFICULTY.THREE:
                Debug.Log("difficultiy Three");
                difficulty3.difficultyThree();
                break;
        }
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
        if (numberCake >0 )
            numberCakeToCollect.text = "Cake Left : " + numberCake.ToString();
        else
            GameWin();
    }
}
