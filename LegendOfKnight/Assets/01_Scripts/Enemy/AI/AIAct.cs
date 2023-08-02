using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIAct : MonoBehaviour
{
    protected EnemyAIBrain _brain;
    protected EnemyController _enemyController;
    protected EnemySword _enemySword;

    protected virtual void Awake()
    {
        _brain = transform.parent.GetComponent<EnemyAIBrain>();
        _enemyController = transform.parent.parent.GetComponent<EnemyController>();
        _enemySword = transform.parent.parent.GetComponentInChildren<EnemySword>();
    }

    public abstract void PlayAct();
}
