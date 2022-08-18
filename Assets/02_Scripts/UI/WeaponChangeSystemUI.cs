using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponChangeSystemUI : MonoBehaviour
{
    public Image _fireWeapon;
    public Image _fireWeaponImage;
    public Image _waterWeapon;
    public Image _waterWeaponImage;
    public Image _elecWeapon;
    public Image _elecWeaponImage;

    public void ToFireWeaponUI()
    {
        _fireWeapon.color = Color.white;
        _fireWeaponImage.color = Color.white;
    }

    public void OnFireWeaponUI()
    {
        _fireWeapon.color = Color.red;
        _fireWeaponImage.color = Color.red;
    }

    public void OutFireWeaponUI()
    {
        Color color = _fireWeapon.color;
        Color color1 = _fireWeaponImage.color; 

        color.a = 0.4f;
        color1.a = 0.4f;

        _fireWeapon.GetComponent<Image>().color = color;
        _fireWeaponImage.GetComponent<Image>().color = color1;
    }

    public void ToWaterWeaponUI()
    {
        _waterWeapon.color = Color.white;
        _waterWeaponImage.color = Color.white;
    }

    public void OnWaterWeaponUI()
    {
        print("111");
        _waterWeapon.color = Color.blue;
        _waterWeaponImage.color = Color.blue;
    }

    public void OutWaterWeaponUI()
    {
        Color color = _waterWeapon.color;
        Color color1 = _waterWeaponImage.color;

        color.a = 0.4f;
        color1.a = 0.4f;

        _waterWeapon.GetComponent<Image>().color = color;
        _waterWeaponImage.GetComponent<Image>().color = color1;
    }

    public void ToElecWeaponUI()
    {
        _elecWeapon.color = Color.white;
        _elecWeaponImage.color = Color.white;
    }

    public void OnElecWeaponUI()
    {
        _elecWeapon.color = Color.yellow;
        _elecWeaponImage.color = Color.yellow;
    }

    public void OutElecWeaponUI()
    {
        Color color = _elecWeapon.color;
        Color color1 = _elecWeaponImage.color;

        color.a = 0.4f;
        color1.a = 0.4f;

        _elecWeapon.GetComponent<Image>().color = color;
        _elecWeaponImage.GetComponent<Image>().color = color1;
    }
}
