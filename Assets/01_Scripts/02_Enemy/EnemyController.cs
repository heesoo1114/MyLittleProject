using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // ���� ã�Ƽ� �̵��� ������Ʈ
    NavMeshAgent _navMeshAgent;

    // ������Ʈ�� ������
    [SerializeField]
    Transform target;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            // ������Ʈ���� �������� �˷��ִ� �Լ�
            _navMeshAgent.SetDestination(target.position);
        }*/

        _navMeshAgent.SetDestination(target.position);
    }
}
