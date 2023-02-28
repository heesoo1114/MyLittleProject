using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    Board _board;

    public bool isOver = false;

    // 시간 세는 기능 넣기

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }

        _board = FindObjectOfType<Board>();
    }

    private void Start()
    {
        _board.openCount = 0;
        _board.InitBoard();
        _board.InstantiateBoard();
    }

    public void NewGame()
    {
        _board.RemoveBoard();
        _board.InitBoard();
        _board.InstantiateBoard();
        isOver = false;
    }

    public void GameOver()
    {
        isOver = true;
        _board.OpenBoard();
    }

    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); 
#endif     
    }
}
