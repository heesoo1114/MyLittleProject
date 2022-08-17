using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public UnityEvent ShootingOn;
    // public UnityEvent ShootingOff;

    private WeaponChangeSystem _wcy;
    [SerializeField] protected WeaponDataSO _weaponData;
    public WeaponDataSO WeaponData 
    { 
        get => _weaponData;
        set => _weaponData = value;
    }

    protected bool delayOn = false;
    protected bool shootingOn = false;

    public Transform _muzzle; // 총알출구

    // Ammo 관련 코드
    public UnityEvent<int> OnAmmoChange; // 총알 변경시 발생할 이벤트
    [SerializeField] protected int _ammo; // 현재 총알 수

    public int Ammo
    {
        get => _ammo;
        set
        {
            _ammo = Mathf.Clamp(value, 0, _weaponData.ammoCapacity);
            OnAmmoChange?.Invoke(_ammo);
        }
    }

    public bool AmmoFull { get => Ammo == _weaponData.ammoCapacity; }
    public int EmptyBulletCnt { get => _weaponData.ammoCapacity - _ammo; }

    // Reload Sound 관련 
    public UnityEvent OnPlayNoAmmo;
    public UnityEvent OnPlayReload;

    //  WeaponDataChaneSystem Q, E Input 관련
    public UnityEvent ChangeWeaponQ;
    public UnityEvent ChangeWeaponE;

    private void Awake()
    {
        _wcy = transform.parent.parent.GetComponentInChildren<WeaponChangeSystem>();
        Ammo = _weaponData.ammoCapacity;
        WeaponAudio wa = transform.Find("WeaponAudio").GetComponent<WeaponAudio>();
        wa.SetAudioClip(_weaponData.shootClip,
                        _weaponData.noAmmoClip,
                        _weaponData.reloadClip);
    }

    private void Update()
    {
        UseWeapon();
        ChangeWeaponData();
    }

    private void ChangeWeaponData()
    {
        _weaponData = _wcy._weaponData;
        if ( Input.GetKeyDown(KeyCode.Q))
        {
            ChangeWeaponQ?.Invoke();
        }
        else if ( Input.GetKeyDown(KeyCode.E))
        {
            ChangeWeaponE?.Invoke();
        }
    }

    private void UseWeapon()
    {
        if ( shootingOn == true && delayOn == false)
        {
            if (_ammo > 0)
            {
                ShootingOn?.Invoke();
                ShootBullet();
                Ammo -= 1;
            }
            else
            {
                shootingOn = false;
                PlayCannotSound();
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
    public void PlayReloadSound()
    {
        OnPlayReload?.Invoke();
    }

    public void PlayCannotSound()
    {
        OnPlayNoAmmo?.Invoke();
    }
}
