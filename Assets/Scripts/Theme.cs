using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Theme : ScriptableObject
{
    public string themeName;
    [Header("Buttons")]
    public Sprite EASY;
    public Sprite NORMAL, HARD, MENU, RETRY, PLAY, SETTINGS, SHOP, BACK;
    [Header("Background")]
    public Sprite Background;
    [Header("WallColor")]
    public Color WallColor;
    [Header("Character")]
    public GameObject Character;
    [Header("Collectible")]
    public GameObject Collectible;
}
