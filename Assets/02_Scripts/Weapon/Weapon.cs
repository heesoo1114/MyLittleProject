using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    private WeaponAudio wa;

    #region 발사 관련 로직
    public UnityEvent ShootingOn;
    // public UnityEvent ShootingOff;

    [SerializeField] protected WeaponDataSO _weaponData;
    public WeaponDataSO WeaponData
    {
        get => _weaponData;
        set => _weaponData = value;
    }

    protected bool delayOn = false;
    protected bool shootingOn = false;

    public Transform _muzzle; // 총알출구
    #endregion

    #region Mana 관련 로직
    public UnityEvent<int> OnAmmoChange; // 총알 변경시 발생할 이벤트
    [SerializeField] protected int _mana; // 현재 마나 수

    public int Mana
    {
        get => _mana;
        set
        {
            _mana = Mathf.Clamp(value, 0, _weaponData.manaAmount);
            OnAmmoChange?.Invoke(_mana);
        }
    }

    public bool ManaFull { get => Mana == _weaponData.manaAmount; }
    public int EmptyManaCnt { get => _weaponData.manaAmount - _mana; }
    #endregion
    // Reload Sound 관련 
    public UnityEvent OnPlayNoAmmo;
    public UnityEvent OnPlayReload;

    //  WeaponDataChaneSystem Q, E Input 관련
    private WeaponChangeSystem _wcy;
    public UnityEvent ChangeWeaponQ;
    public UnityEvent ChangeWeaponE;

    #region ChargingSkill 관련 로직
    // ChargingSkill 관련 
    [HideInInspector]
    public bool ChargingOn = false;
    public UnityEvent NowFireState;
    public UnityEvent NowWaterState;
    public UnityEvent NowElecState;

    // 스킬 사용 가능 상태 확인
    public bool IsFireOn = false;
    public bool IsWaterOn = false;
    public bool IsElecOn = false;

    // 스킬 사용중인지 확인
    public bool FireSkillRunning = false;
    public bool WaterSkillRunning = false;
    public bool ElecSkillRunning = false;
    public bool AnySkillRunning = false;
    #endregion

    private void Awake()
    {
        _wcy = transform.parent.parent.GetComponentInChildren<WeaponChangeSystem>();
        Mana = _weaponData.manaAmount;
        wa = transform.Find("WeaponAudio").GetComponent<WeaponAudio>();
        wa.SetAudioClip(_weaponData.shootClip,
                        _weaponData.noAmmoClip,
                        _weaponData.reloadClip);
    }

    private void Update()
    {
        UseWeapon();
        UseChargingSkill();
        ChangeWeaponData();
        AnySkillRunningCheck();
        wa.SetAudioClip(_weaponData.shootClip, _weaponData.noAmmoClip, _weaponData.reloadClip);
    }

    private void AnySkillRunningCheck()
    {
        if (FireSkillRunning == true || ElecSkillRunning == true || WaterSkillRunning == true)
        {
            AnySkillRunning = true;
        }
        else if (FireSkillRunning == false && ElecSkillRunning == false && WaterSkillRunning == false)
        {
            AnySkillRunning = false;
        }
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

    private void UseChargingSkill()
    {
        if ( ChargingOn == true )
        {
            if ( Mana >= 20 )
            {
                if (AnySkillRunning == false)
                {
                    if (_wcy.NowFire == true && IsFireOn == true)
                    {
                        NowFireState?.Invoke();
                        Mana -= 20;
                    }
                    else if (_wcy.NowElec == true && IsElecOn == true)
                    {
                        NowElecState?.Invoke();
                        Mana -= 20;
                    }
                    else if (_wcy.NowWater == true && IsWaterOn == true)
                    {
                        NowWaterState?.Invoke();
                        Mana -= 20;
                    }
                    else if (_wcy.NowFire == true && IsFireOn == false && FireSkillRunning == false)
                    {
                        StopCharging();
                        print("스킬을 사용할 수 없습니다"); // UI로 고치기
                    }
                    else if (_wcy.NowElec == true && IsElecOn == false && ElecSkillRunning == false)
                    {
                        StopCharging();
                        print("스킬을 사용할 수 없습니다"); // UI로 고치기
                    }
                    else if (_wcy.NowWater == true && IsWaterOn == false && WaterSkillRunning == false)
                    {
                        StopCharging();
                        print("스킬을 사용할 수 없습니다"); // UI로 고치기
                    }
                    else if (AnySkillRunning == true)
                    {
                        print("스킬을 사용하고 있습니다"); // UI로 고치기
                        return;
                    }
                }
            }
            else
            {
                ChargingOn = false;
                print("마나가 부족합니다"); // UI 패널로 고치기
            }
        }
    }

    private void UseWeapon()
    {
        if ( shootingOn == true && AnySkillRunning == false)
        {
            if (_mana > 0)
            {
                ShootingOn?.Invoke();
                ShootBullet();
                Mana -= 2;
            }
            else
            {
                shootingOn = false;
                PlayCannotSound();
                return;
            }
            shootingOn = false;
        }
        else if(shootingOn == true && AnySkillRunning == true)
        {
            print("스킬이 실행중입니다");
        }
    }

    public void ShootBullet()
    {
        SpawnBullet(_muzzle.position, _muzzle.rotation , false);
    }

    private void SpawnBullet(Vector3 position, Quaternion rot, bool isEnemyBullet)
    {
        Bullet bullet = Instantiate(_weaponData.bulletData.bulletPrefab).GetComponent<Bullet>(); // 풀링으로 변경
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

    public void TryCharging()
    {
        ChargingOn = true;
    }
    public void StopCharging()
    {
        ChargingOn = false;
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
