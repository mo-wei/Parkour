using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Ö÷²Ëµ¥
/// </summary>
public class MainManu : MonoBehaviour
{
    public void Begin()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void Qiut()
    {
        Application.Quit();
    }
}