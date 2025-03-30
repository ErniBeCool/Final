using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public Toggle soundToggle;
    public Slider volumeSlider;
    public Button backButton;

    void Start()
    {
        if (soundToggle == null || volumeSlider == null || backButton == null)
        {
            Debug.LogError("Не все элементы UI назначены в SettingsController!");
            return;
        }

        soundToggle.onValueChanged.AddListener(OnSoundToggleChanged);
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
        backButton.onClick.AddListener(() => OnBackButton());

        LoadSettings();
    }


    private void OnSoundToggleChanged(bool isOn)
    {
        AudioListener.volume = isOn ? volumeSlider.value : 0f;
        PlayerPrefs.SetInt("SoundOn", isOn ? 1 : 0);
        Debug.Log("Звук " + (isOn ? "включен" : "выключен"));
    }

    private void OnVolumeSliderChanged(float value)
    {
        if (soundToggle.isOn)
        {
            AudioListener.volume = value;
        }
        PlayerPrefs.SetFloat("Volume", value);
        Debug.Log("Громкость установлена на: " + value);
    }

    private void OnBackButton()
    {
        LoadingScreen.LoadScene("MainMenu"); // Через LoadingScreen
    }

    private void LoadSettings()
    {
        soundToggle.isOn = PlayerPrefs.GetInt("SoundOn", 1) == 1;
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        AudioListener.volume = soundToggle.isOn ? volumeSlider.value : 0f;
    }
}