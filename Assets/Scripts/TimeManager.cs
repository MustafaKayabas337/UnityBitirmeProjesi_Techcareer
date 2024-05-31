using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float currentTime = 0f;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScore;
    [SerializeField] private AudioSource audioSource;
    private bool timerIsActive = false;
    private SpawnManager spawnManager;


    private void Awake()
    {
        highScore.text = "Highscore:" + (PlayerPrefs.GetInt("Highscore", 0)).ToString();
        audioSource.time = PlayerPrefs.GetFloat("AudioTime", 0f);
        audioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 1f);
    }

    private void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }
    private void Update()
    {
        if (!timerIsActive && Input.touchCount > 0)
        {
            timerIsActive = true;
            spawnManager.SpawnStart();
        }

        if (timerIsActive)
        {
            currentTime += Time.deltaTime % 60;
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            timeText.text = "Time:" + time.ToString("mm':'ss':'ff");
            scoreText.text = "Score:" + ((int)time.TotalSeconds * ((int)time.TotalMinutes + 1) - ((int)time.TotalMinutes) * 60);
        }

    }
}
