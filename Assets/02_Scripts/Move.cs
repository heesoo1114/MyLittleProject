using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;

    // Update is called once per frame
    public void Update()
    {
        float x = Input.GetAxis("Vertical");
        float Y = Input.GetAxis("Horizontal");

        Vector3 dir = new Vector3(Y, x, 0);

        transform.position += dir * moveSpeed * Time.deltaTime;
    }
}
