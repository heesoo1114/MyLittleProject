using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHp : MonoBehaviour
{
    public UnityEvent DieEvent;
    public UnityEvent DieOver1fEvent;
    public UnityEvent GetHitEvent;

    public bool IsEnemy => false;

    public bool _isDead = false;

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

    public void DelayInvoke()
    {
        Invoke("DieOverEventInvoke", 0.6f);
    }

    public void DieOverEventInvoke()
    {
        DieOver1fEvent?.Invoke();
    }

    public void ConTimeScale()
    {
        Time.timeScale = 0;
    }
}
