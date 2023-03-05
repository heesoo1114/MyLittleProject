using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDecision : MonoBehaviour
{
    private EnemyBrain _brain;
    

    private void Awake()
    {
        _brain = GetComponentInParent<EnemyBrain>();
    }

    private void Update()
    {
        CalDistance();
    }

    private void CalDistance()
    {
        float distance = Vector2.Distance(_brain.BasePosition.position, _brain.Target.position);

        if(distance < _brain._enemyData.canAttackRange)
        {
            _brain.TryAttack();
        }
        else
        {
            _brain.StopAttack();
        }
    }
}
