using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaUI : MonoBehaviour
{
    public GameObject magicwand;
    private Weapon _weapon;
    private Slider _manaSlider;

    private void Awake()
    {
        _weapon = magicwand.GetComponent<Weapon>();
        _manaSlider = GetComponent<Slider>();   
    }

    private void Update()
    {
        _manaSlider.value = _weapon.Mana;
    }
}
