using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionCanAttack : AIDecision
{
    [SerializeField]
    [Range(0.1f, 30f)]
    private float _distance = 5f;
    public float Distance { get => _distance; set => _distance = Mathf.Clamp(value, 0.1f, 30f); }

    RaycastHit hit;

    public override bool CheckDecision()
    {
        if (Physics.Raycast(_enemyController.BasePosition.position, _enemyController.BasePosition.forward, out hit, _distance))
        {
            Debug.DrawRay(_enemyController.BasePosition.position, _enemyController.BasePosition.forward * hit.distance);
            if (hit.collider.name != "Player") return false;
            return true;
        }
        else
        {
            return false;
        }
    }

/*#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (UnityEditor.Selection.activeGameObject == gameObject)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(_enemyController.BasePosition.position, _enemyController.BasePosition.forward * hit.distance);
            Gizmos.color = Color.white;
        }
    }
#endif*/
}
