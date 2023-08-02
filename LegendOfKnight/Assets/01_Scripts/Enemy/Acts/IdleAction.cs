using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : AIAct
{
    public override void PlayAct()
    {
        _enemyController.canChase = false;
    }
}
