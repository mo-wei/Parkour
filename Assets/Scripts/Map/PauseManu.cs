using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;
/// <summary>
/// ÔÝÍ£²Ëµ¥
/// </summary>
public class PauseManu : MonoBehaviour
{
    public GameObject pauseManu;
    public AudioMixer audioMixer;
    public GameObject coinNumText;

    public void upgradeCoinNum(int num)
    {
        coinNumText.GetComponent<TMP_Text>().text = "X" + num.ToString();
    }
    public void ReturnMain()
    {
        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        pauseManu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenPauseManu()
    {
        pauseManu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ControlVoice(float value)
    {
        audioMixer.SetFloat("Volume", value);
    }

    public void GameAgain()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
}