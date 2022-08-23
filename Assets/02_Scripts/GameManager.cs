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

    [HideInInspector] public Weapon _weapon;
    public Weapon Weapon
    {
        get => _weapon;
    }

    public GameObject ThunderPrefabs;

    [HideInInspector] public Thunder _thunder;
    public Thunder Thunder
    {
        get => _thunder;
    }

    public GameObject CssFDB;
    [HideInInspector] public ChargingSkillSystem _chargingSkillSystem;
    public ChargingSkillSystem ChargingSkillSystem => _chargingSkillSystem;

    private void Awake()
    {
        _playerHp = Player.GetComponent<PlayerHp>();
        _weapon = Player.transform.Find("Weapon").GetComponentInChildren<Weapon>();
        _thunder = ThunderPrefabs.GetComponent<Thunder>();
        _chargingSkillSystem = CssFDB.GetComponent<ChargingSkillSystem>();

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
