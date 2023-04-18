using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Ó²±Ò½Å±¾
/// </summary>
public class Coin : MonoBehaviour
{
    public bool isMagnet;
    private float MagnetTime;
    private float moveSpeed;
    private PlayerController character;

    private void Start()
    {
        character = FindObjectOfType<PlayerController>();
        moveSpeed = 0.5f;
    }

    private void Update()
    {
        MoveToCharacter();
    }
    

    private void MoveToCharacter()
    {
        if(isMagnet)
        {
            transform.LookAt(character.transform);
            transform.Translate(new Vector3(0, 0, Mathf.Lerp(moveSpeed, 0.2f, 0)));
        }
    }

}