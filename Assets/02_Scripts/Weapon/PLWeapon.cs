using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PLWeapon : MonoBehaviour
{
    private Weapon _weapon; // 자기가 들고 있는 weapon
    private WeaponRenderer _weaponRenderer;
    private float _deireAngle; // 무기가 바라보고자 하는 방향

    [SerializeField]
    private int MaxAmmo = 10000, totalAmmo = 200;
    protected bool _isReloading = false;
    public bool IsReloading { get => _isReloading; }
    private void Awake()
    {
        AssignWeapon();
    }

    public void Shooting()
    {
        // ( 스킬 진행 중 확인 if문 추가 가능성 있음 -> Weapon에 추가하는쪽으로 )
        if(_isReloading == true)
        {
            _weapon.PlayCannotSound();
            return;
        }
        _weapon.TryShooting();
    }

    public void StopShooting()
    {
        _weapon.StopShooting();
    }

    public void AssignWeapon()
    {
        _weaponRenderer = GetComponentInChildren<WeaponRenderer>();
        _weapon = GetComponentInChildren<Weapon>();
    }

    public void AimWeapon(Vector2 pointerPos)
    {
        Vector3 aimDirection = (Vector3)pointerPos - transform.position;
        _deireAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        AdjustWeaponRendering(); // 무기를 렌더링

        transform.rotation = Quaternion.AngleAxis(_deireAngle, Vector3.forward);
    }

    private void AdjustWeaponRendering()
    {
        _weaponRenderer.FlipSprite(_deireAngle > 90f || _deireAngle < -90f);
        _weaponRenderer.RenderBehindHead(_deireAngle > 0 && _deireAngle < 180f);
    }

    public void ReloadWeapon()
    {
        if( _isReloading == false && totalAmmo > 0  && _weapon.AmmoFull == false)
        {
            _isReloading = true;
            _weapon.StopShooting();
            StartCoroutine(ReloadAmmo());
        }
    }

    IEnumerator ReloadAmmo()
    {
        _weapon.PlayReloadSound();
        int reloadAmmo = Mathf.Min(totalAmmo, _weapon.EmptyBulletCnt);
        totalAmmo -= reloadAmmo;
        _weapon.Ammo += reloadAmmo;

        _isReloading = false;
        yield return null;
    }
}
