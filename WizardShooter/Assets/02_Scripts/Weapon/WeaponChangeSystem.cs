using UnityEngine;
using UnityEngine.Events;

public class WeaponChangeSystem : MonoBehaviour
{
    public WeaponDataSO _fireWeaponData;
    public WeaponDataSO _waterWeaponData;
    public WeaponDataSO _elecWeaponData;
    public WeaponDataSO _iceWeaponData;

    public UnityEvent ToFireWeaponData;
    public UnityEvent ToWaterWeaponData;
    public UnityEvent ToElecWeaponData;

    [HideInInspector] public bool NowFire = true;
    [HideInInspector] public bool NowWater = false;
    [HideInInspector] public bool NowElec = false;

    private SpriteRenderer _spriteRenderer;
    private Weapon _weapon;
    public WeaponDataSO _weaponData;
    private WeaponDataSO WeaponData 
    { 
        get => _weaponData;
        set => _weaponData = value; 
    }

    private void Awake()
    {
        _weapon = transform.parent.Find("Weapon").GetComponentInChildren<Weapon>();
        _spriteRenderer = transform.parent.Find("Weapon").GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        // ��¡���� �Ұ� Ȯ�� if�� �ڵ�
        if (_weaponData == _fireWeaponData)
        {
            NowFire = true;
            ToFireWeaponData?.Invoke();
        }
        else if (_weaponData == _waterWeaponData)
        {
            NowWater = true;
            ToWaterWeaponData?.Invoke();
        }
        else if (_weaponData == _elecWeaponData)
        {
            NowElec = true;
            ToElecWeaponData?.Invoke();
        }
    }

    public void PressQ()
    {
        if(_weapon.AnySkillRunning == false)
        {
            if (NowFire == true)
            {
                ToElecWeapon();
            }
            else if (NowWater == true)
            {
                ToFireWeapon();
            }
        }
        else
        {
            print("��ų�� ����ϰ� �ֽ��ϴ�."); // UI�� ��ġ��
        }
    }

    public void PressE()
    {
        if (_weapon.AnySkillRunning == false)
        {
            if (NowFire == true)
            {
                ToWaterWeapon();
            }
            else if (NowElec == true)
            {
                ToFireWeapon();
            }
        }
        else
        {
            print("��ų�� ����ϰ� �ֽ��ϴ�."); // UI�� ��ġ��
        }
    }

    private void ToFireWeapon()
    {
        _weaponData = _fireWeaponData;
        _spriteRenderer.sprite = _weaponData.weaponSprite;
        NowFire = true;
        NowElec = false;
        NowWater = false;
    }

    public void ToWaterWeapon()
    {
        _weaponData = _waterWeaponData;
        _spriteRenderer.sprite = _weaponData.weaponSprite;
        NowWater = true;
        NowElec = false;
        NowFire = false;
    }

    private void ToElecWeapon()
    {
        _weaponData = _elecWeaponData;
        _spriteRenderer.sprite = _weaponData.weaponSprite;
        NowElec = true;
        NowWater = false;
        NowFire = false;
    }

    public void ToIceWeapon()
    {
        _weaponData = _iceWeaponData;
    }
    public void ResetToWaterWeapon()
    {
        _weaponData = _waterWeaponData;
    }
}