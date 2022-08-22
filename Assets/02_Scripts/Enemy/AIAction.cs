using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAction : MonoBehaviour
{
    private EnemyBrain _brain;
    private bool IsHit = true;

    private int _damage;
    private float _delayTime;

    private void Awake()
    {
        _brain = transform.parent.parent.GetComponent<EnemyBrain>();
    }

    private void Start()
    {
        _damage = _brain._enemyData.damage;
        _delayTime = _brain._enemyData.attackDelay;
    }

    public void MeleAttack()
    {
        RaycastHit2D hit = Physics2D.Raycast(_brain.BasePosition.position, transform.right, _brain._enemyData.attackRange);

        if (hit && IsHit == true)
        {
            print("hit");
            GameManager.Instance._playerHp.Health -= _damage;
            StartCoroutine(UpdateHp());
        }
        else
        {
            StopCoroutine(UpdateHp());
        }
    }

    IEnumerator UpdateHp()
    {
        IsHit = false;
        yield return new WaitForSeconds(_delayTime);
        IsHit = true;
    }
}
