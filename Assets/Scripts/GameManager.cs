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
/// 
/// </summary>

public enum DIFFICULTY {
    ONE,
    TWO,
    THREE
}

public class GameManager : MonoBehaviour
{
    private DIFFICULTY difficulty = DIFFICULTY.THREE;
    [SerializeField] private LevelGenerator levelGenerator;
    private GameObject farCamera;
    private Animator animator;
    public AudioMixer audioMixer;

    [Header ("Panel UI")]
    public GameObject mainPanel;
    public GameObject winPanel, losePanel;

    [Header ("Health")]
    public int health = 3;
    public Image health_1,  health_2, health_3;

    [Header ("Score")]
    public int score;
    public int numberCake;
    public TextMeshProUGUI scoreText, numberCakeToCollect;

    [Header ("Player")]
    public GameObject player;

    private void Start() {
        farCamera = GameObject.Find("Main Camera");
        animator = gameObject.GetComponent<Animator>();
    }

    /// <summary>
    /// 
    /// These methods are for buttons in the UI
    /// 
    /// </summary>

    public void RestartGame() {
        Time.timeScale = 1;
        score = 0;
        health = 3;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackMainMenu() {
        Time.timeScale = 1;
        score = 0;
        health = 3;

        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    public void GameOver() {
        Time.timeScale = 0;
        mainPanel.SetActive(false);
        losePanel.SetActive(true);
    }

    public void GameWin() {
        Time.timeScale = 0;
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

    /// <summary>
    /// 
    /// The both Methods are responsible to determine which level should be generated. Then after choose the level, it will call the script LevelGenerator
    /// Also need to initialize the clone player afterwards
    /// 
    /// </summary>

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
                Debug.Log("difficulty One");
                levelGenerator = GameObject.Find("Level Design 1").GetComponent<LevelGenerator>();

                levelGenerator.difficultyOne();
                farCamera.GetComponent<Transform>().transform.position = new Vector3(-22.5f, 47.5f, -50);

                break;

            case DIFFICULTY.TWO:
                Debug.Log("difficulty Two");
                levelGenerator = GameObject.Find("Level Design 2").GetComponent<LevelGenerator>();

                levelGenerator.difficultyTwo();
                farCamera.GetComponent<Transform>().transform.position = new Vector3(-14, 68, -50);

                break;

            case DIFFICULTY.THREE:
                Debug.Log("difficulty Three");

                levelGenerator = GameObject.Find("Level Design 3").GetComponent<LevelGenerator>();
                levelGenerator.difficultyThree();

                break;
        }
    }

    public void SetPlayer() {
        player = GameObject.Find("Player(Clone)");
    }

    /// <summary>
    /// 
    /// These methods are responsible for UI Elements (score, point left, health)
    /// 
    /// </summary>

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

    /// <summary>
    /// 
    /// To change the play mode, between close and far mode play
    /// 
    /// </summary>

    public void SetCameraClose() {
        //player.GetComponent<PlayerController_Click>().enabled = false;
        farCamera.SetActive(false);
        player.transform.GetChild(1).transform.gameObject.SetActive(true);
    }

    public void SetCameraFar() {
        //player.GetComponent<PlayerController_Click>().enabled = true;
        farCamera.SetActive(true);
        player.transform.GetChild(1).transform.gameObject.SetActive(false);
    }

    /// <summary>
    /// 
    /// To activate the animator
    /// 
    /// </summary>

    public void SetPlayAnimation() {
        animator.StopPlayback();
        animator.Play("GameTransition");
    }
}
