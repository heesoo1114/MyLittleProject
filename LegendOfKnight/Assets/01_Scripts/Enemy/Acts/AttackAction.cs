using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : AIAct
{
    bool isAttacking = false;
    public float attackDelay = 0.8f;

    public override void PlayAct()
    {
        if (isAttacking) return;
        
        StartCoroutine(AttackCor());
    }

    IEnumerator AttackCor()
    {
        isAttacking = true;
        _enemyController.canChase = false;

        yield return new WaitForSeconds(attackDelay * 2f);

        _enemyController.AttackAnimation();

        yield return new WaitForSeconds(0.41f);
        _enemySword._collider.enabled = true;
        _enemySword._trailRenderer.enabled = true;

        yield return new WaitForSeconds(0.5f);
        _enemySword._collider.enabled = false;
        _enemySword._trailRenderer.enabled = false;

        _enemyController.StopAttackAnimation();

        yield return new WaitForSeconds(attackDelay);

        _enemyController.canChase = true;
        isAttacking = false;
    }
}
