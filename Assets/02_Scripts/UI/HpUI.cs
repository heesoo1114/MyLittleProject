using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUI : MonoBehaviour
{
    public GameObject Player;
    private PlayerHp _playerHp;

    private Slider _hpSlider;
    public Text _hpText;

    private void Awake()
    {
        _playerHp = Player.GetComponent<PlayerHp>();
        _hpSlider = GetComponent<Slider>();
    }

    public void Update()
    {
        _hpSlider.value = _playerHp.Health;
        string stringHp = _playerHp.Health.ToString();
        _hpText.text = stringHp;
    }
}
