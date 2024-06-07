using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SfxController : MonoBehaviour
{
    [SerializeField] AudioSource coinCollect;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private TMP_Text SFXText;
    private void Awake()
    {
        float volume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        coinCollect.volume = volume;
        SFXSlider.value = volume;
        SFXText.text = (SFXSlider.value).ToString("0.0");
    }


    public void UpdateAudioVolume()
    {
        coinCollect.volume = SFXSlider.value;
        SFXText.text = (SFXSlider.value).ToString("0.0");
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
    }
    public void CoinCollectPlayAudio()
    {
        coinCollect.Play();
    }
}
