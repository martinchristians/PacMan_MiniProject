using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

/// <summary>
/// this script is responsible for all UI Element in MainMenu
/// 
/// @author : Martin Christian Solihin
/// </summary>

public class SettingMainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float vol) {
        audioMixer.SetFloat("mainVolume", vol);
    }

    public void StartGame() {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
