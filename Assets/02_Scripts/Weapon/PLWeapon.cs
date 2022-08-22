using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PLWeapon : MonoBehaviour
{
    private Weapon _weapon; // �ڱⰡ ��� �ִ� weapon
    private WeaponRenderer _weaponRenderer;
    private float _deireAngle; // ���Ⱑ �ٶ󺸰��� �ϴ� ����

    private int totalMana = 100;
    protected bool _isReloading = false;
    public bool IsReloading { get => _isReloading; }
    private void Awake()
    {
        AssignWeapon();
    }

    public void Shooting()
    {
        if(_isReloading == true)
        {
            print("������ ä��� �ֽ��ϴ�"); // UI�� ��ġ�� 
            return;
        }
        _weapon.TryShooting();
    }

    public void Charging()
    {
        if(_isReloading == true)
        {
            print("������ ä��� �ֽ��ϴ�"); // UI�� ��ġ�� 
            return;
        }
        _weapon.TryCharging();
    }

    public void StopShooting()
    {
        _weapon.StopShooting();
    }

    public void StopCharging()
    {
        _weapon.StopCharging();
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
        if( _isReloading == false && totalMana > 0 && _weapon.ManaFull == false && _weapon.AnySkillRunning == false)
        {
            _isReloading = true;
            _weapon.StopShooting();
            StartCoroutine(ReloadAmmo());
        }
        else if(_isReloading == false && totalMana > 0 && _weapon.ManaFull == false && _weapon.AnySkillRunning == true)
        {
            print("��ų�� ������Դϴ�."); // UI �гη� ��ġ��
        }
    }

    IEnumerator ReloadAmmo()
    {
        // yield return new WaitForSeconds(_weapon.WeaponData.reloadDelay);

        _weapon.PlayReloadSound();
        int reloadMana = Mathf.Min(totalMana, _weapon.EmptyManaCnt);
        totalMana -= reloadMana;
        // _weapon.Mana += reloadMana;
        for(int i = 0; i < reloadMana; i++)
        {
            _weapon.Mana += 1;
            yield return new WaitForSeconds(0.1f);
        }
        totalMana += 100;
        _isReloading = false;
    }
}
