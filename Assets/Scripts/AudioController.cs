using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private TMP_Text MusicText;
    private void Awake()
    {
        float time;
        if (SceneManager.GetActiveScene().name == "MainMenu") time = 0f;
        else time = PlayerPrefs.GetFloat("AudioTime", 0f);
        audioSource.time = time;
        float volume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        audioSource.volume = volume;
        MusicSlider.value = volume;
        MusicText.text = (MusicSlider.value).ToString("0.0");
    }
    private void Start()
    {
        audioSource.Play();
    }

    public void UpdateAudioVolume()
    {
        audioSource.volume = MusicSlider.value;
        MusicText.text = (MusicSlider.value).ToString("0.0");
        PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
    }
}
