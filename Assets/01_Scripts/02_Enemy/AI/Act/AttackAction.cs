using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : AIAct
{
    public override void PlayAct()
    {
        Debug.Log("AttackAction");
        _enemyController.EnemyStop();
        _gunController.FireBullet();
    }
}
