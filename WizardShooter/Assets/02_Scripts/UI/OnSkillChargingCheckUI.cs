using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnSkillChargingCheckUI : MonoBehaviour
{
    public GameObject Weapon;
    private Weapon _weapon;

    public UnityEvent OnFireSkill;
    public UnityEvent OffFireSkill;
    public UnityEvent OnWaterSkill;
    public UnityEvent OffWaterSkill;
    public UnityEvent OnElecSkill;
    public UnityEvent OffElecSkill;

    private void Awake()
    {
        _weapon = Weapon.GetComponent<Weapon>();
    }
}
