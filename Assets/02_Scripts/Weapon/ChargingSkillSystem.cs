using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChargingSkillSystem : MonoBehaviour
{
    private Weapon _weapon;
    private WeaponChangeSystem _wcy;
    
    public int stack = 10;

    public int fireShootCount = 0;
    public int waterShootCount = 0;
    public int elecShootCount = 0;

    private void Awake()
    {
        _weapon = transform.parent.GetComponent<Weapon>();
        _wcy = transform.parent.parent.parent.GetComponentInChildren<WeaponChangeSystem>();
    }


    public void NormalShootCount()
    {
        if (_wcy.NowFire == true)
        {
            fireShootCount++;
        }
        else if (_wcy.NowWater == true)
        {
            waterShootCount++;
        }
        else if (_wcy.NowElec == true)
        {
            elecShootCount++;
        }
    }

    private void Update()
    {
        CanUseSkill();
    }

    private void CanUseSkill()
    {
        if ( fireShootCount >= stack )
        {
            _weapon.IsFireOn = true;
        }
        if ( waterShootCount >= stack )
        {
            _weapon.IsWaterOn = true;
        }
        if ( elecShootCount >= stack )
        {
            _weapon.IsElecOn = true;
        }
    }

    // charchingOn = false; 를 스킬 feedback이 전부 끝났을 때 실행하게 해야 함
    public void FireCircle()
    {
        print("fire");
        _weapon.ChargingOn = false;
        fireShootCount = 0;
    }

    public void Thunder()
    {
        print("elec");
        _weapon.ChargingOn = false;
        elecShootCount = 0;
    }

    public void Icicle()
    {
        print("water");
        _weapon.ChargingOn = false;
        waterShootCount = 0;
    }
}
