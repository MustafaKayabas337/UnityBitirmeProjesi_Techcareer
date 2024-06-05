using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float currentTime = 0f;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScore;
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private AudioSource audioSource;

    private bool isGameStarted = false;
    private SpawnManager spawnManager;
    private TimeSpan gameTime;
    private void Awake()
    {
        highScore.text = "Highscore:" + (PlayerPrefs.GetInt("Highscore", 0)).ToString();
        audioSource.time = PlayerPrefs.GetFloat("AudioTime", 0f);
        audioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        coinText = (GameObject.Find("/Canvas/GameScreen/CoinText")).GetComponent<TMP_Text>();
        int coin = PlayerPrefs.GetInt("Coin", 0);
        coinText.text = ":" + coin.ToString();
    }

    private void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        StartCoroutine(ScoreCounter());
    }

    private void Update()
    {
        if (isGameStarted)
        {
            currentTime += Time.deltaTime % 60;
            gameTime = TimeSpan.FromSeconds(currentTime);
            timeText.text = "Time:" + gameTime.ToString("mm':'ss':'ff");
        }
    }
    private IEnumerator ScoreCounter()
    {
        while (true)
        {
            if (Input.touchCount > 0)
            {
                spawnManager.SpawnStart();
                isGameStarted = true;
                break;
            }
            yield return new WaitForSeconds(0.01f);
        }
        int score = -1;
        while (true)
        {
            score += 1 * (int)(gameTime.TotalMinutes + 1);
            scoreText.text = "Score:" + score.ToString();
            yield return new WaitForSeconds(1f);
        }
    }
}
