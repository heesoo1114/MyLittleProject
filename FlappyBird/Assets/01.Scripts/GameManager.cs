using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    PipeSpawner _spawner;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        _spawner = FindObjectOfType<PipeSpawner>();
    }

    private void Start()
    {
        GameStart();
    }

    public void GameStart()
    {
        TimePlay();
        _spawner.SpawnStart();
    }

    public void GameOver()
    {
        _spawner.SpawnStop();
        TimeStop();
    }

    public void TimeStop()
    {
        Time.timeScale = 0;
    }

    public void TimePlay()
    {
        Time.timeScale = 1;
    }
}
    