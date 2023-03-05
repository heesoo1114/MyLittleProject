using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChargingSkillSystem : MonoBehaviour
{
    // ThunderEffect 생성 지점
    [HideInInspector] public Vector3 _position;
    private Vector3 Position 
    { get => _position; set => _position = value; }

    public Camera _camera;
    private CameraRaycast _cameraRaycast;
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
    // public WeaponDataSO IceWandData;
    // private Icicle _icicle;
    public GameObject ThunderPrefab;
    private Thunder _thunder;

    private void Awake()
    {
        _cameraRaycast = _camera.GetComponent<CameraRaycast>();
        _weapon = transform.parent.GetComponent<Weapon>();
        _wcy = transform.parent.parent.parent.GetComponentInChildren<WeaponChangeSystem>();
        _osccUI = OsccUI.GetComponent<OnSkillChargingCheckUI>();

        _fireCircle = fireCirclePrefab.GetComponent<FireCircle>();
        _thunder = ThunderPrefab.GetComponent<Thunder>();
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

    // charchingOn = false; 를 스킬 feedback이 전부 끝났을 때 실행하게 해야 함
    public void FireCircle()
    {
        fireShootCount = 0; // 중요 이거 안 해두면 IsFowerOn이 무한으로 돌아서 스킬이 마나가 없을때까지 돌아감
        _weapon.FireSkillRunning = true;
        StartCoroutine(FireCircleCreate());   
    }

    IEnumerator FireCircleCreate()
    {
        Vector3 CreatePosition = new Vector3(0, 0, 0);
        // GameObject fireCircle = Instantiate(fireCirclePrefab, CreatePosition, Quaternion.identity); // 풀링으로 변경
        FireCircle fireCircle = PoolManager.Instance.Pop(fireCirclePrefab.name) as FireCircle;
        fireCircle.transform.SetPositionAndRotation(CreatePosition, Quaternion.identity);
        yield return new WaitForSeconds(_fireCircle.delayTime);
        // Destroy(fireCircle);  // 풀링으로 변경
        PoolManager.Instance.Push(fireCircle);
        _weapon.ChargingOn = false;
        _weapon.FireSkillRunning = false;
    }

    public void Thunder() // ButtonPress
    {
        _weapon.ElecSkillRunning = true;
    }

    public void TunderEffectCreate() // ButtonRealease
    {
        _cameraRaycast.CalMpToCp();
        _position = _cameraRaycast.CreatePosition;
        StartCoroutine(ThunderCreate(_position));
        elecShootCount = 0;
    }

    IEnumerator ThunderCreate(Vector3 ps)
    {
        Vector3 position = ps;
        // GameObject thunder = Instantiate(ThunderPrefab, position, Quaternion.identity); // 풀링으로 변경
        Thunder thunder = PoolManager.Instance.Pop(ThunderPrefab.name) as Thunder;
        thunder.transform.SetPositionAndRotation(position, Quaternion.identity);
        _thunder._onThunder = true; 

        yield return new WaitForSeconds(_thunder.delayTime);

        // Destroy(thunder); // 풀링으로 변경
        PoolManager.Instance.Push(thunder);
        _weapon.ChargingOn = false;
        _weapon.ElecSkillRunning= false;
        _thunder._onThunder = false; 
    }

    public void Icicle()
    {
        waterShootCount = 0;
        _weapon.WaterSkillRunning = true;
        StartCoroutine(ChangeIceFromWater());
    }

    IEnumerator ChangeIceFromWater()
    {
        _wcy.ToIceWeapon();
        while(true)
        {
            for(int i = 0; i < 3; i ++)
            {
                if(i == 0) yield return new WaitForSeconds(_weapon.WeaponData.shootDelay);
                _weapon.ShootBullet();
                if (i == 2) break;
                yield return new WaitForSeconds(_weapon.WeaponData.shootDelay);
            }
            break;
        }
        _wcy.ResetToWaterWeapon();
        _weapon.ChargingOn = false;
        _weapon.WaterSkillRunning = false;
    }
    
}
