using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleLine : MonoBehaviour
{
    CircleCollider2D _circleCollider;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _circleCollider.isTrigger = true;
        }
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            Debug.Log("col");
            collision.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("not col");
        }
    }
}
