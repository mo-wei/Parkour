using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ÈËÎï¿ØÖÆÆ÷
/// </summary>
[RequireComponent(typeof(PlayerMove))]
[RequireComponent(typeof(PlayerInfo))]

public class PlayerController : MonoBehaviour
{
    private PlayerMove playerMove;
    private PlayerInfo playerInfo;

    private void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerInfo = GetComponent<PlayerInfo>();
    }

    private void Update()
    {
        playerMove.RollPress();
        playerMove.JumpPress();
        playerMove.TurnLeft();
        playerMove.TurnRight();
        playerMove.KeepRightRoad();
        playerMove.Fly();
        playerMove.PickFlyBackpack();
        playerInfo.PickMagnet();
    }

    private void FixedUpdate()
    {
        playerMove.Roll();
        playerMove.Jumping();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.gameObject.tag == "Car" || hit.collider.gameObject.tag == "Fence")
        {
            playerInfo.PlayerDie();
        }
    }
}