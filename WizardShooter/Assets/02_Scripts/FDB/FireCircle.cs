using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCircle : PoolAbleMono
{
    private GameObject Player;
    [HideInInspector] public Transform PlayerPosition;
    public float damage = 3;
    public float delayTime = 5.5f;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Init();
    }

    private void Update()
    {
        transform.position = Player.transform.position;
    }

    public override void Init()
    {
        
    }
}
