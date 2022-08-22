using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [SerializeField]
    private Texture2D _cursorSprite = null;

    public GameObject Player;

    [HideInInspector] public Transform _playerPosition;
    public Transform PlayerPosition
    {
        get => _playerPosition = Player.transform;
    }

    [HideInInspector] public PlayerHp _playerHp;
    public PlayerHp PlayerHp
    {
        get => _playerHp;
    }

    private void Awake()
    {
        _playerHp = Player.GetComponent<PlayerHp>();

        if (Instance != null)
        {
            Debug.Log("Multiple Gamemanager is running");
        }
        Instance = this;

        SetCursorSprite();
    }

    private void SetCursorSprite()
    {
        Cursor.SetCursor(_cursorSprite, new Vector2(_cursorSprite.width / 2f, _cursorSprite.height / 2f), (CursorMode.ForceSoftware));
    }
}
