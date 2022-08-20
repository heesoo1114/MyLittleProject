using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaUI : MonoBehaviour
{
    public GameObject magicwand;
    private Weapon _weapon;

    private Slider _manaSlider;
    public Text _manaText;

    private void Awake()
    {
        _weapon = magicwand.GetComponent<Weapon>();
        _manaSlider = GetComponent<Slider>();   
    }

    public void Update()
    {
        _manaSlider.value = _weapon.Mana;
        string stringMana = _weapon.Mana.ToString();
        _manaText.text = stringMana;
    }
}
