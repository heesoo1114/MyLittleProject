using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIBrain : MonoBehaviour
{
    EnemyController _enemyController;

    [SerializeField] private AIState currentState;

    private void Awake()
    {
        _enemyController = transform.parent.GetComponent<EnemyController>();   
    }

    void Update()
    {
        currentState.UpdateState();
    }

    public void ChangeState(AIState state)
    {
        currentState = state;
    }
}
