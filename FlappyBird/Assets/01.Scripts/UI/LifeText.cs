using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeText : MonoBehaviour
{
    TextMeshProUGUI _tmp;

    private int currentLife;

    private void Awake()
    {
        _tmp = GetComponent<TextMeshProUGUI>(); 
    }

    public void UpdateLifeText(int nextLife)
    {
        currentLife = nextLife;
        _tmp.text = "Life: " + currentLife;
    }
}
