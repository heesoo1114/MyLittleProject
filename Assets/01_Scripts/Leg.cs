using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : MonoBehaviour
{
    CapsuleCollider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _collider.size = new Vector2(1, 0.8f);
    }
}
