using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// 人物信息
/// </summary>
public class PlayerInfo : MonoBehaviour
{
    public PauseManu pauseManu;
    private int coinNum;
    public GameObject gameOverManu;
    public GameObject distanceNumText;
    public GameObject coinNumText;
    public GameObject Magnet;
    private float MagnetTime;
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Magnet":
                MagnetTime = 8f;
                AudioManager.instance.MagnetAudio();
                Destroy(other.gameObject);
                break;
            case "Coin":
                Destroy(other.gameObject);
                coinNum += 1;
                AudioManager.instance.Coin1Audio();
                pauseManu.upgradeCoinNum(coinNum);
                break;
            case "CoinStar":
                Destroy(other.gameObject);
                coinNum += 5;
                AudioManager.instance.CoinStarAudio();
                pauseManu.upgradeCoinNum(coinNum);
                break;
            case "Jetpack":
                Destroy(other.gameObject);
                AudioManager.instance.JetpackAudio();
                this.GetComponent<PlayerMove>().isFly = true;
                FindObjectOfType<ObstacleCreator>().isfly = true;
                break;
            default:
                break;
        }
    }

    public void PickMagnet()
    {
        if(MagnetTime > 0)
        {
            Magnet.SetActive(true);
            MagnetTime -= Time.deltaTime;
        }
        else
        {
            Magnet.SetActive(false);
        }
    }

    public void PlayerDie()
    {
        //游戏结束
        gameOverManu.SetActive(true);
        distanceNumText.GetComponent<TMP_Text>().text = (4 * Time.timeSinceLevelLoad + coinNum).ToString();
        coinNumText.GetComponent<TMP_Text>().text = coinNum.ToString();
        Time.timeScale = 0f;
        //播放游戏结束音乐
        this.GetComponent<AudioSource>().Stop();
        AudioManager.instance.DieAudio();

    }
}