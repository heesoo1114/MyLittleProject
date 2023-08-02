using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour
{
    Sword _sword;

    private void Awake()
    {
        _sword = transform.parent.GetComponent<Sword>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // 플레이어의 칼과 적이 부딪혔을 때
            _sword.HitEnemy(other.gameObject);
        }
    }
}
