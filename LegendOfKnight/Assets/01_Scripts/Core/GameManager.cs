using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    SpawnManager _spawnManager;

    public Transform player;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _spawnManager = transform.parent.GetComponentInChildren<SpawnManager>();
    }

    private void Start()
    {
        Time.timeScale = 1f;
        _spawnManager.SpawnStart(3, 5f);      
    }
}
