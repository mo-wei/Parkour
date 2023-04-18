using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ’œ∞≠ŒÔ
/// </summary>
public class Obstacle : MonoBehaviour
{
    public float moveSpeed;
    private void Update()
    {
        this.transform.Translate(0, 0, -Time.deltaTime * moveSpeed);
        if(this.transform.position.z < -20)
        {
            Destroy(this.gameObject);
        }
    }
}