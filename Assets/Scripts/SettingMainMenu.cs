using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// this script is responsible for UI Elements in MainMenu
/// 
/// @author : Martin Christian Solihin
/// </summary>

public class SettingMainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    private float valueAudio;
    private bool isThereAudio;
    public Slider sliderVolume;

    private void Start() {
        // to get the current value of audio that might already change in Main menu
        isThereAudio = audioMixer.GetFloat("mainVolume", out valueAudio);
        if (isThereAudio)
            sliderVolume.value = valueAudio;
    }

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
