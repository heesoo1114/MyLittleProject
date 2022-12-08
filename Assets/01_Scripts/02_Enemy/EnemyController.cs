using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // ���� ã�Ƽ� �̵��� ������Ʈ
    NavMeshAgent _navMeshAgent;

    // ������Ʈ�� ������
    private Transform target;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        target = GameManager.Instance.player.transform;
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            // ������Ʈ���� �������� �˷��ִ� �Լ�
            _navMeshAgent.SetDestination(target.position);
        }*/
        if (target != null)
        {
            _navMeshAgent.SetDestination(target.position);
        }
    }
}
