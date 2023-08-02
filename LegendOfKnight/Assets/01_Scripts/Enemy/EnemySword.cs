using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour
{
    [HideInInspector] public BoxCollider _collider; // ���� �ִ� ����
    [HideInInspector] public TrailRenderer _trailRenderer; // �ܻ�

    private void Awake()
    {
        _collider = GetComponentInChildren<BoxCollider>();
        _trailRenderer = GetComponentInChildren<TrailRenderer>();
    }
}
