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
        // 어딘가에 부딪혔을 때 총알 삭제
        PoolManager.Instance.Push(this);

        if (collision.gameObject.CompareTag("Enemy")) // 적에 충돌했을 때
        {
            Destroy(collision.gameObject); // 적 삭제
        }
    }

    public override void Init()
    {
        // not thing
    }
}
