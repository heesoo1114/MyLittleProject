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
            // �÷��̾��� Į�� ���� �ε����� ��
            _sword.HitEnemy(other.gameObject);
        }
    }
}
