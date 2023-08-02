using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _rigid;

    public float jumpPower;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rigid.velocity = Vector2.up * jumpPower;
    }
}
