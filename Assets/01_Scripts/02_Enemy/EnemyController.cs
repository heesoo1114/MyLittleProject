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
}
