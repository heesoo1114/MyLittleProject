using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLWeapon : MonoBehaviour
{
    private Weapon _weapon; // �ڱⰡ ��� �ִ� weapon
    private WeaponRenderer _weaponRenderer;
    private float _deireAngle; // ���Ⱑ �ٶ󺸰��� �ϴ� ����



    private void Awake()
    {
        AssignWeapon();
    }

    public void Shooting()
    {
        // ���߿� ���� ���� Ȯ�� if�� �߰� ,, ( ��ų ���� �� Ȯ�� if�� �߰� ���ɼ� ���� -> Weapon�� �߰��ϴ������� )
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
}
