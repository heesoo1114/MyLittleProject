using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : AIAct
{
    public override void PlayAct()
    {
        // _enemyController.Target = null;
        _enemyController._navMeshAgent.velocity = Vector3.zero;
        Debug.Log("IdleAction");
    }
}
