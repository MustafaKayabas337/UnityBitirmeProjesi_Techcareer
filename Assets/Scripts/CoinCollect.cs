using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private AudioSource coinPickSfx;
    [SerializeField] private GameObject glowAfterPickUp;
    private void Awake()
    {
        coinPickSfx = (GameObject.Find("/CoinPickupSFX")).GetComponent<AudioSource>();
        coinText = (GameObject.Find("/Canvas/GameScreen/CoinText")).GetComponent<TMP_Text>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        coinPickSfx.Play();
        int coin = PlayerPrefs.GetInt("Coin", 0);
        PlayerPrefs.SetInt("Coin", ++coin);
        coinText.text = ":" + coin.ToString();
        var obj = Instantiate(glowAfterPickUp, transform.position , Quaternion.identity, transform.parent);
        obj.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -1); 
        Destroy(this.gameObject);
    }

}
