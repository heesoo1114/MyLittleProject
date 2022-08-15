using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLWeapon : MonoBehaviour
{
    private Weapon _weapon; // 자기가 들고 있는 weapon
    private WeaponRenderer _weaponRenderer;
    private float _deireAngle; // 무기가 바라보고자 하는 방향



    private void Awake()
    {
        AssignWeapon();
    }

    public void Shooting()
    {
        // 나중에 장전 상태 확인 if문 추가 ,, ( 스킬 진행 중 확인 if문 추가 가능성 있음 -> Weapon에 추가하는쪽으로 )
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
}
