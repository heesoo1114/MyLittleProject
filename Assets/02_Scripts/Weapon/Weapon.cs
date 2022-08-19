using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    private WeaponAudio wa;

    #region �߻� ���� ����
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

    public Transform _muzzle; // �Ѿ��ⱸ
    #endregion

    #region Mana ���� ����
    public UnityEvent<int> OnAmmoChange; // �Ѿ� ����� �߻��� �̺�Ʈ
    [SerializeField] protected int _mana; // ���� ���� ��

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
    // Reload Sound ���� 
    public UnityEvent OnPlayNoAmmo;
    public UnityEvent OnPlayReload;

    //  WeaponDataChaneSystem Q, E Input ����
    private WeaponChangeSystem _wcy;
    public UnityEvent ChangeWeaponQ;
    public UnityEvent ChangeWeaponE;

    #region ChargingSkill ���� ����
    // ChargingSkill ���� 
    [HideInInspector]
    public bool ChargingOn = false;
    public UnityEvent NowFireState;
    public UnityEvent NowWaterState;
    public UnityEvent NowElecState;

    // ��ų ��� ���� ���� Ȯ��
    public bool IsFireOn = false;
    public bool IsWaterOn = false;
    public bool IsElecOn = false;

    // ��ų ��������� Ȯ��
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
                        print("��ų�� ����� �� �����ϴ�"); // UI�� ��ġ��
                    }
                    else if (_wcy.NowElec == true && IsElecOn == false && ElecSkillRunning == false)
                    {
                        StopCharging();
                        print("��ų�� ����� �� �����ϴ�"); // UI�� ��ġ��
                    }
                    else if (_wcy.NowWater == true && IsWaterOn == false && WaterSkillRunning == false)
                    {
                        StopCharging();
                        print("��ų�� ����� �� �����ϴ�"); // UI�� ��ġ��
                    }
                    else if (AnySkillRunning == true)
                    {
                        print("��ų�� ����ϰ� �ֽ��ϴ�"); // UI�� ��ġ��
                        return;
                    }
                }
            }
            else
            {
                ChargingOn = false;
                print("������ �����մϴ�"); // UI �гη� ��ġ��
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
            print("��ų�� �������Դϴ�");
        }
    }

    public void ShootBullet()
    {
        SpawnBullet(_muzzle.position, _muzzle.rotation , false);
    }

    private void SpawnBullet(Vector3 position, Quaternion rot, bool isEnemyBullet)
    {
        Bullet bullet = Instantiate(_weaponData.bulletData.bulletPrefab).GetComponent<Bullet>(); // Ǯ������ ����
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
