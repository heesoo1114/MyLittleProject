using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour 
{
    private EnemyAIBrain _brain = null;
    
    [Header("Action")]
    [SerializeField]
    private List<AIAct> _acts = null;

    // Decisions
    [Header("Decision List")]
    [SerializeField]
    private List<AIDecision> _positiveDecisions = null;
    [SerializeField]
    private List<AIDecision> _negativeDecisions = null;

    // State Route
    [Header("Route State")]
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
            if (act == null) Debug.LogError("Act is null");
            act.PlayAct();
        }

        // State Route
        bool positive = false;
        bool negative = false;

        foreach (AIDecision decision in _positiveDecisions)
        {
            if (decision == null) Debug.LogError("Decision is null");

            positive = decision.CheckDecision();
            if (positive == false) break;
            _brain.ChangeState(PositiveState);
            return;
        }

        foreach (AIDecision decision in _negativeDecisions)
        {
            if (decision == null) Debug.LogError("Decision is null");

            negative = decision.CheckDecision();
            if (negative == false) break;
            _brain.ChangeState(NegativeState);
            return;
        }
    }
}
