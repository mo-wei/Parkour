using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// »ÀŒÔ“∆∂Ø
/// </summary>
public class PlayerMove : MonoBehaviour
{
    private CharacterController characterController;

    public float gravity;
    public float jumpHeight;
    public float speed;
    public float flyHeight;
    private Vector3 currentDirection;
    public float YSpeed;
    private bool isJumpPress;
    private bool isRollPress;
    private Animator animator;
    public Avatar[] avatars;//0.run 1.roll 2.fly
    private Road road;
    private float xRoad;

    public float rollTime;
    private float deltaRollTime;

    public float FlyTime;
    public bool isFly;




    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        currentDirection = new Vector3();
        animator = GetComponent<Animator>();
        road = Road.MIDDLE;
    }

    public void RollPress()
    {
        if (characterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.C) && deltaRollTime < 0)
            {
                isRollPress = true;
            }
        }
        deltaRollTime -= Time.deltaTime;
    }
    public void Roll()
    {
        if (isRollPress)
        {
            isRollPress = false;
            characterController.height = 1f;
            deltaRollTime = rollTime;
            animator.avatar = avatars[1];
            animator.SetBool("Rolling", true);
        }

        if (deltaRollTime < 0 && !animator.GetBool("Flying"))
        {
            characterController.height = 2f;
            animator.avatar = avatars[0];
            animator.SetBool("Rolling", false);
        }
    }

    public void JumpPress()
    {
        if (characterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumpPress = true;
            }
        }
    }

    public void Jumping()
    {
        if (isJumpPress)
        {
            animator.SetBool("Jumping", true);
            currentDirection.y = jumpHeight;
            isJumpPress = false;
        }
        if (currentDirection.y > -10)
        {
            currentDirection.y -= gravity * Time.deltaTime;
        }
        if (animator.GetBool("Jumping") && currentDirection.y <= -10)
        {
            animator.SetBool("Jumping", false);

        }

        characterController.Move(currentDirection * Time.deltaTime);
    }


    public void TurnLeft()
    {
        if (characterController.isGrounded || animator.GetBool("Flying"))
        {
            if (road == Road.MIDDLE)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    currentDirection.x = -speed;
                    road = Road.LEFT;

                    return;
                }
            }

            if (road == Road.RIGHT)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    currentDirection.x = -speed;
                    road = Road.MIDDLE;
                    return;
                }
            }
        }

    }
    public void TurnRight()
    {
        if (characterController.isGrounded || animator.GetBool("Flying"))
        {
            if (road == Road.LEFT)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    currentDirection.x = speed;
                    road = Road.MIDDLE;
                    return;
                }
            }

            if (road == Road.MIDDLE)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    currentDirection.x = speed;
                    road = Road.RIGHT;
                    return;
                }
            }
        }


    }
    public void KeepRightRoad()
    {
        switch (road)
        {
            case Road.LEFT:
                xRoad = -4;
                break;
            case Road.MIDDLE:
                xRoad = 0;
                break;
            case Road.RIGHT:
                xRoad = 4;
                break;
        }


        if (Mathf.Abs(transform.position.x - xRoad) < 0.1f)
        {
            currentDirection.x = 0;
        }
        if(Mathf.Abs(transform.position.z - (-4)) > 0.1f)
        {
            currentDirection.z = 1;
        }
        else
        {
            currentDirection.z = 0;
        }

    }

    public void PickFlyBackpack()
    {
        if(isFly)
        {
            FlyTime = 10f;
            isFly = false;
            animator.avatar = avatars[2];
            animator.SetBool("Flying", true);
        }
    }

    public void Fly()
    {
        if(FlyTime > 0)
        {
            FlyTime -= Time.deltaTime;
            if (Mathf.Abs(this.transform.position.y - flyHeight) < 0.1)
            {
                currentDirection.y = 0f;
            }
            else
            {
                YSpeed = Mathf.Lerp(YSpeed, 5, 0.1f);
                currentDirection.y = YSpeed;
                
            }
            gravity = 0;
        }
        if(FlyTime < 0)
        {
            gravity = 20f;
            if (characterController.isGrounded && !animator.GetBool("Rolling"))
            {
                animator.avatar = avatars[0];
                animator.SetBool("Flying", false);
            }
        }

    }
}