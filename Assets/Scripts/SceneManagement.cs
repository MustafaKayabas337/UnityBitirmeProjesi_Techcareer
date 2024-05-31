using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public void ChangeScene(string sceneName)
    {
        PlayerPrefs.SetFloat("AudioTime", audioSource.time);
        SceneManager.LoadScene(sceneName);
    }
}
