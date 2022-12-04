using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rigidbody;

    private Vector3 velocity;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 getVelocity)
    {
        velocity = getVelocity;
    }

    public void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectPoint);
    }

    private void FixedUpdate()
    {
        // MovePosition(���� ��ġ + �̵��� �ӷ� + �����ð�)
        _rigidbody.MovePosition(_rigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
