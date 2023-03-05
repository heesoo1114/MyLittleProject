using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : AIAct
{
    public override void PlayAct()
    {
        Debug.Log("IdleAction");
        _enemyController.EnemyStop();
    }
}
