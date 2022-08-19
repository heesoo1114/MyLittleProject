using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChargingSkillSystem : MonoBehaviour
{
    private Weapon _weapon;
    private WeaponChangeSystem _wcy;
    public GameObject OsccUI;
    private OnSkillChargingCheckUI _osccUI;

    public int stack = 10;

    public int fireShootCount = 0;
    public int waterShootCount = 0;
    public int elecShootCount = 0;

    public GameObject fireCirclePrefab;
    private FireCircle _fireCircle;
    public GameObject IciclePrefab;
    // private Icicle _icicle;
    public GameObject ThunderPrefab;
    // private Thunder _thunder;

    private void Awake()
    {
        _weapon = transform.parent.GetComponent<Weapon>();
        _wcy = transform.parent.parent.parent.GetComponentInChildren<WeaponChangeSystem>();
        _osccUI = OsccUI.GetComponent<OnSkillChargingCheckUI>();

        _fireCircle = fireCirclePrefab.GetComponent<FireCircle>();
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
        if (fireShootCount >= stack)
        {
            _weapon.IsFireOn = true;
            _osccUI.OnFireSkill?.Invoke();
        }
        else if (fireShootCount < stack)
        {
            _weapon.IsFireOn = false;
            _osccUI.OffFireSkill?.Invoke();
        }

        if ( waterShootCount >= stack )
        {
            _weapon.IsWaterOn = true;
            _osccUI.OnWaterSkill?.Invoke();
        }
        else if (waterShootCount < stack)
        {
            _weapon.IsWaterOn = false;
            _osccUI.OffWaterSkill?.Invoke();
        }

        if ( elecShootCount >= stack )
        {
            _weapon.IsElecOn = true;
            _osccUI.OnElecSkill?.Invoke();
        }
        else if (elecShootCount < stack)
        {
            _weapon.IsElecOn= false;
            _osccUI.OffElecSkill?.Invoke();
        }
    }

    // charchingOn = false; �� ��ų feedback�� ���� ������ �� �����ϰ� �ؾ� ��
    public void FireCircle()
    {
        print("fireSkill");
        fireShootCount = 0; // �߿� �̰� �� �صθ� IsFowerOn�� �������� ���Ƽ� ��ų�� ������ ���������� ���ư�
        _weapon.FireSkillRunning = true;
        StartCoroutine(FireCircleCreate());   
    }

    IEnumerator FireCircleCreate()
    {
        Vector3 CreatePosition = new Vector3(0, 0, 0);
        GameObject fireCircle = Instantiate(fireCirclePrefab, CreatePosition, Quaternion.identity); // Ǯ������ ����
        yield return new WaitForSeconds(_fireCircle.delayTime);
        Destroy(fireCircle);  // Ǯ������ ����
        _weapon.ChargingOn = false;
        _weapon.FireSkillRunning = false;
    }

    public void Thunder()
    {
        print("elecSkill");
        _weapon.ChargingOn = false;
        elecShootCount = 0;
    }

    public void Icicle()
    {
        print("waterSkill");
        _weapon.ChargingOn = false;
        waterShootCount = 0;
    }

    
}
