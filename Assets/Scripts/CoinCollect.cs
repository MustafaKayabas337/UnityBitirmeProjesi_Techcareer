using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    private void Awake()
    {
        coinText = (GameObject.Find("/Canvas/GameScreen/CoinText")).GetComponent<TMP_Text>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int coin = PlayerPrefs.GetInt("Coin", 0);
        PlayerPrefs.SetInt("Coin", ++coin);
        coinText.text = ":" + coin.ToString();
        Destroy(this.gameObject);
    }
}
