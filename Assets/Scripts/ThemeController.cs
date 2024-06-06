using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThemeController : MonoBehaviour
{
    [SerializeField] private string SceneName;
    [Header("Themes")]
    [SerializeField] private Theme[] themes;
    [Header("Buttons")]
    [SerializeField] private Image EASY; 
    [SerializeField] private Image NORMAL, HARD, MENU, RETRY, PLAY, SETTINGS, SHOP, SETTINGSBACK, DIFFICULTYBACK;
    [Header("Background")]
    [SerializeField] private Image Background;
    [Header("GameScreen")]
    [SerializeField] private GameObject GameScreen;
    [Header("Walls")]
    [SerializeField] private SpriteRenderer[] Walls;
    private Theme theme;
    public void Awake()
    {
        string themeName = PlayerPrefs.GetString("Theme", "ClassicTheme");

        foreach(Theme theme in themes)
        {
            if(theme.themeName == themeName)
            {
                this.theme = theme;
                break;
            }
        }

        if (SceneName == "MainMenu")
        {
            EASY.sprite = theme.EASY;
            NORMAL.sprite = theme.NORMAL;
            HARD.sprite = theme.HARD;
            PLAY.sprite = theme.PLAY;
            SETTINGS.sprite = theme.SETTINGS;
            SHOP.sprite = theme.SHOP;
            SETTINGSBACK.sprite = theme.BACK;
            DIFFICULTYBACK.sprite = theme.BACK;
            Background.sprite = theme.Background;
        }
        else if(SceneName == "EasyLevel")
        {
            MENU.sprite = theme.MENU;
            RETRY.sprite = theme.RETRY;
            Background.sprite = theme.Background;
            Instantiate(theme.Character, new Vector3(0f,0f,-2f), Quaternion.identity, GameScreen.transform);
            foreach (SpriteRenderer wall in Walls)
                wall.color = theme.WallColor;
        }
    }

    public void ChangeTheme()
    {
        string themeName = PlayerPrefs.GetString("Theme", "ClassicTheme");
        if (themeName == "ClassicTheme")
            PlayerPrefs.SetString("Theme", "MouseTheme");
        else
            PlayerPrefs.SetString("Theme", "ClassicTheme");
        SceneManager.LoadScene("MainMenu");
    }
}
