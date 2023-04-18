using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 平面的移动
/// </summary>
public class Land : MonoBehaviour
{
    //储存所有子物体中的平面块
    public GameObject[] childrenLands;
    public float moveSpeed;

    private void FixedUpdate()
    {
        LandMove();
    }

    private void LandMove()
    {
        //都要向后走去
        for (int i = 0; i < childrenLands.Length; i++)
        {
            childrenLands[i].transform.Translate(0, 0, -moveSpeed * Time.fixedDeltaTime);
            if (childrenLands[i].transform.position.z < -20)
            {
                childrenLands[i].transform.position = new Vector3(0, 0, 60);
            }
        }
    }
}