using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// @author : Martin Christian Solihin
/// </summary>

public class GameManager : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void BackMainMenu() {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
