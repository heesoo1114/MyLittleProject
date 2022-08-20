using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHp : MonoBehaviour
{
    public bool IsEnemy => false;

    private bool _isDead = false;

    #region 체력관련 부분
    [SerializeField]
    private int _maxHealth;
    private int _health;
    public int Health
    {
        get => _health;
        set
        {
            _health = Mathf.Clamp(value, 0, _maxHealth);
        }
    }
    #endregion

    private void Awake()
    {
        _health = _maxHealth;
    }

}
