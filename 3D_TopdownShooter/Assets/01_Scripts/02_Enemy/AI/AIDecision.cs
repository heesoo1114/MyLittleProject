using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIDecision : MonoBehaviour
{
    protected EnemyAIBrain _brain;
    protected EnemyController _enemyController;

    protected virtual void Awake()
    {
        _brain = transform.parent.GetComponent<EnemyAIBrain>();
        _enemyController = transform.parent.parent.GetComponent<EnemyController>();
    }

    public abstract bool CheckDecision();
}
