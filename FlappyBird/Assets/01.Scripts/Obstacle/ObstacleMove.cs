using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float moveSpeed;

    private void Update()
    {
        transform.Translate(moveSpeed * Vector3.left * Time.deltaTime, Space.World);
    }
}
