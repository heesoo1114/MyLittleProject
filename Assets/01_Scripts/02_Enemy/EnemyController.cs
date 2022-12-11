using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // 길을 찾아서 이동할 에이전트
    NavMeshAgent _navMeshAgent;

    Rigidbody _rigidbody;

    // 에이전트의 목적지
    private Transform target;
    public Transform Target
    {
        get => target;
        set => target = value;
    }

    [SerializeField] private Transform basePosition;
    public Transform BasePosition
    {
        get => basePosition;
    }

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        target = GameManager.Instance.player.transform;
    }

    void Update()
    {
        if (target != null)
        {
            _navMeshAgent.SetDestination(target.position);
        }
    }

    public void EnemyStop()
    {
        _navMeshAgent.velocity = Vector3.zero;
    }
}
