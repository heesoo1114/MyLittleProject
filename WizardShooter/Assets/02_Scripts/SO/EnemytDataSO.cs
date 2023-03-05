using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/EnmeyData")]
public class EnemytDataSO : ScriptableObject
{
    public string enemyName;
    public GameObject prefab;
    public int maxHealth = 10;
    public float knockbackRegist = 1f;

    public int damage = 1;
    public float attackDelay = 1;
    public float attackRange = 1;
    public float canAttackRange = 0.8f;
}
