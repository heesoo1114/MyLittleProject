using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public UnityEvent ShootingOn;
    // public UnityEvent ShootingOff;

    [SerializeField] protected WeaponDataSO _weaponData;
    public WeaponDataSO WeaponData { get => _weaponData; }

    protected bool delayOn = false;
    protected bool shootingOn = false;

    public Transform _muzzle; // ÃÑ¾ËÃâ±¸

    // Ammo
    public UnityEvent AmmoChangeOn;
    protected int _ammo = 1;

    private void Update()
    {
        UseWeapon();
    }

    private void UseWeapon()
    {
        if ( shootingOn == true && delayOn == false)
        {
            if (_ammo > 0)
            {
                ShootingOn?.Invoke();
                ShootBullet();
            }
            else
            {
                shootingOn = false;
                return;
            }
            FinishShooting();
        }
    }

    private void FinishShooting()
    {
        // StartCoroutine(DelayShootTime());
        shootingOn = false;
    }

    IEnumerator DelayShootTime()
    {
        delayOn = true;
        yield return new WaitForSeconds(_weaponData.shootDelay);
        delayOn = false;
    }

    private void ShootBullet()
    {
        SpawnBullet(_muzzle.position, _muzzle.rotation , false);
    }

    private void SpawnBullet(Vector3 position, Quaternion rot, bool isEnemyBullet)
    {
        Bullet bullet = Instantiate(_weaponData.bulletData.bulletPrefab).GetComponent<Bullet>();
        bullet.SetPositionAndRotation(position, rot);
        bullet.IsEnemy = isEnemyBullet;
        bullet.BulletData = _weaponData.bulletData;
    }

    public void TryShooting()
    {
        shootingOn = true;
    }

    public void StopShooting()
    {
        shootingOn = false;
    }
}
