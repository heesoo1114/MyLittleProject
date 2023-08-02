using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    private int health;
    public int Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0, maxHealth);
        }
    }

    public bool isDead = false;

    public UnityEvent GetHit;
    public UnityEvent OnDie;
    public UnityEvent<int> OnUpdateHpUI;

    private void Awake()
    {
        Health = maxHealth;
    }

    public void GetDamage(int damage)
    {
        if (isDead) return;

        health -= damage;
        Debug.Log(damage);
        OnUpdateHpUI?.Invoke(health);

        if (health > 0)
        {
            GetHit?.Invoke();
        }

        if (health <= 0)
        {
            OnDie?.Invoke();
            isDead = true;
        }
    }
}
