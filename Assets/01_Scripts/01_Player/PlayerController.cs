using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rigidbody;

    private Vector3 velocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        // MovePosition(현재 위치 + 이동할 속력 + 단위시간)
        _rigidbody.MovePosition(_rigidbody.position + velocity * Time.fixedDeltaTime);
    }

    public void Move(Vector3 getVelocity)
    {
        velocity = getVelocity;
    }

    public void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectPoint = new(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectPoint);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            print("isWall");
        }
    }
}
