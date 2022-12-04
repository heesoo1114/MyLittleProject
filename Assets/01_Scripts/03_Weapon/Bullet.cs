using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolAbleMono
{
    public float bulletSpeed = 5f;

    public void Update()
    {
        // transform.position += Vector3.forward * bulletSpeed * Time.deltaTime;
        BulletMove();
    }

    private void BulletMove()
    {
        transform.Translate(bulletSpeed * Time.deltaTime * Vector3.forward);
    }

    public void SetProperties(float newSpeed, Quaternion newRot, Transform newPosition)
    {
        bulletSpeed = newSpeed;
        transform.rotation = newRot;
        transform.position = newPosition.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        PoolManager.Instance.Push(this);
    }

    public override void Init()
    {
        // not thing
    }
}
