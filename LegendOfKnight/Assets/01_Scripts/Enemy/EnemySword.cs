using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour
{
    [HideInInspector] public BoxCollider _collider; // ²¨Á® ÀÖ´Â »óÅÂ
    [HideInInspector] public TrailRenderer _trailRenderer; // ÀÜ»ó

    private void Awake()
    {
        _collider = GetComponentInChildren<BoxCollider>();
        _trailRenderer = GetComponentInChildren<TrailRenderer>();
    }
}
