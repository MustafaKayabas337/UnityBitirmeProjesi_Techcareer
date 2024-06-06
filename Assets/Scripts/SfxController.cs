using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxController : MonoBehaviour
{
    [SerializeField] AudioSource coinCollect;

    public void CoinCollectPlayAudio()
    {
        coinCollect.Play();
    }
}
