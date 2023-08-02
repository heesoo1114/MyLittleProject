using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent<int> OnUpdateLifeUI;

    public int maxLife = 3;
    private int life = 3;
    public int Life
    {
        get => life;
        set
        {
            life = Mathf.Clamp(value, 0, maxLife);
            OnUpdateLifeUI?.Invoke(life);
        }
    }

    public int score = 0;

    private void Awake()
    {
        life = maxLife;
        score = 0;
    }

    public void LifeMinus()
    {
        Life--;
        
        if (Life <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    public void ScorePlus()
    {
        score += 10;
    }
}
