using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Texture2D _cursorSprite = null;

    private void Start()
    {
        SetCursorSprite();
    }

    private void SetCursorSprite()
    {
        Cursor.SetCursor(_cursorSprite, new Vector2(_cursorSprite.width / 2f, _cursorSprite.height / 2f), (CursorMode.ForceSoftware));
    }
}
