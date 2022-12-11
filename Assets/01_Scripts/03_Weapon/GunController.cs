using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Bullet bullet; // Bullet Prefab;

    [Range(0f, 2f)] 
    public float delayTime = 1f; // Bullet shooting Delay
    public float muzzleVelocity = 35f;
    public bool canFire = true;

    public Transform muzzle;

    public void FireBullet()
    {
        // Bullet newBullet = Instantiate(bullet, muzzle.position, muzzle.rotation);
        if (!canFire) return;
        Bullet newBullet = PoolManager.Instance.Pop(bullet.name) as Bullet;
        newBullet.SetProperties(muzzleVelocity, muzzle.rotation, muzzle.transform);
        StartCoroutine(ShootDelay(delayTime));
    }

    private IEnumerator ShootDelay(float dlayTime)
    {
        canFire = false;
        yield return new WaitForSeconds(dlayTime);
        canFire = true;
    }
}
