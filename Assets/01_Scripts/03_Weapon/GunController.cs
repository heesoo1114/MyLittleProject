using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Bullet bullet; // Bullet Prefab;

    [Range(0f, 2f)] 
    public float delayTime = 1f; // Bullet shooting Delay
    public float muzzleVelocity = 35f;

    public Transform muzzle;

    public void FireBullet()
    {
        Bullet newBullet = Instantiate(bullet, muzzle.position, muzzle.rotation);
        newBullet.SetSpeed(muzzleVelocity);
    }
}
