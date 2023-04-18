using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ƽ����ƶ�
/// </summary>
public class Land : MonoBehaviour
{
    //���������������е�ƽ���
    public GameObject[] childrenLands;
    public float moveSpeed;

    private void FixedUpdate()
    {
        LandMove();
    }

    private void LandMove()
    {
        //��Ҫ�����ȥ
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