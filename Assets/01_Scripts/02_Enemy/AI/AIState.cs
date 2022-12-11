using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour 
{
    private EnemyAIBrain _brain = null;

    [SerializeField]
    private List<AIAct> _acts = null;
    [SerializeField]
    private List<AIDecision> _decisions = null;

    // State Route
    [Header("Route")]
    public AIState PositiveState;
    public AIState NegativeState;

    private void Awake()
    {
        _brain = transform.parent.GetComponent<EnemyAIBrain>();
    }

    public void UpdateState()
    {
        // Act
        foreach (AIAct act in _acts)
        {
            act.PlayAct();
        }

        // State Route
        bool result = false;

        foreach (AIDecision decision in _decisions)
        {
            result = decision.CheckDecision();
            if (result == false) return;
        }

        // State Change
        if (result == true)
        {
            if (PositiveState == null) return;
            _brain.ChangeState(PositiveState);
        }
        else
        {
            if (NegativeState == null) return;
            _brain.ChangeState(NegativeState);
        }
    }
}
