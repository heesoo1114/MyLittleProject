using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAction : AIAct
{
    public override void PlayAct()
    {
        _enemyController.canChase = true;
    }
}
