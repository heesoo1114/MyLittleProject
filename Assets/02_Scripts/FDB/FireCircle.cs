using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCircle : MonoBehaviour
{
    private GameObject Player;
    [HideInInspector] public Transform PlayerPosition;
    public int damage = 3;
    public float delayTime = 5.5f;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        // PlayerPosition = Player.GetComponent<Transform>();
    }

    private void Update()
    {
        transform.position = Player.transform.position;
    }
}
