using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // 길을 찾아서 이동할 에이전트
    NavMeshAgent _navMeshAgent;

    // 에이전트의 목적지
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
            // 에이전트에게 목적지를 알려주는 함수
            _navMeshAgent.SetDestination(target.position);
        }*/
        if (target != null)
        {
            _navMeshAgent.SetDestination(target.position);
        }
    }
}
