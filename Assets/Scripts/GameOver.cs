using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text gameOverPanel_ScoreText;
    [SerializeField] private GameObject gameOverPanel_HighScoreText;
    [SerializeField] private GameObject gameScreen;

    private void Awake()
    {
        gameOverPanel_HighScoreText.SetActive(false);
    }

    public void endTheGame()
    {
        string scoreText = (GameObject.Find("ScoreText").GetComponent<TMP_Text>().text);
        int score = Int32.Parse(scoreText.Substring(6));
        gameOverPanel.SetActive(true);
        gameScreen.SetActive(false);
        gameOverPanel_ScoreText.text = scoreText;
        int highscore = PlayerPrefs.GetInt("Highscore", 0);
        if(highscore < score)
        {
            PlayerPrefs.SetInt("Highscore", score);
            gameOverPanel_HighScoreText.SetActive(true);
        }
    }
}
