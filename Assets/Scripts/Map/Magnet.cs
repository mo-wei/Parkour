using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ´ÅÌúµÀ¾ß
/// </summary>
public class Magnet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin" || other.tag == "CoinStar")
        {
            other.GetComponent<Coin>().isMagnet = true;
        }
    }
}