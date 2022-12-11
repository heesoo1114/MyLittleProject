using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIAct : MonoBehaviour
{
    protected EnemyAIBrain _brain;
    protected EnemyController _enemyController;
    protected GunController _gunController;

    protected virtual void Awake()
    {
        _brain = transform.parent.GetComponent<EnemyAIBrain>();
        _enemyController = transform.parent.parent.GetComponent<EnemyController>();
        _gunController = transform.parent.parent.GetComponentInChildren<GunController>();
    }

    public abstract void PlayAct();
}
