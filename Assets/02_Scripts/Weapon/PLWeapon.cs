using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PLWeapon : MonoBehaviour
{
    private Weapon _weapon; // �ڱⰡ ��� �ִ� weapon
    private WeaponRenderer _weaponRenderer;
    private float _deireAngle; // ���Ⱑ �ٶ󺸰��� �ϴ� ����

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
        // ( ��ų ���� �� Ȯ�� if�� �߰� ���ɼ� ���� -> Weapon�� �߰��ϴ������� )
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

        AdjustWeaponRendering(); // ���⸦ ������

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
