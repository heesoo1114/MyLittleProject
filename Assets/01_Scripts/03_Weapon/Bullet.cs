using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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

    public void SetSpeed(float newSpeed)
    {
        bulletSpeed = newSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Destroy(collision.gameObject);
        Debug.Log("Collision");
    }
}
