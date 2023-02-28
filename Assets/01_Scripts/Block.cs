using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Info
{
    Mine,
    Number,
    Marking
}

public class Block : MonoBehaviour
{
    Board _board;
    Image _inImage;

    private List<Sprite> spriteList;

    public Info state = Info.Number;
    public int blockID; // -1 ~ 8

    private void Awake()
    {
        _board = transform.parent.GetComponent<Board>();
        _inImage = transform.GetChild(0).GetComponent<Image>();
        spriteList = _board.spriteList;
    }

    public void SetBlock()
    {
        if (blockID == -1)
        {
            state = Info.Mine;
            _inImage.sprite = spriteList[9]; // 지뢰 sprite 넣어주기
            return;
        }

        _inImage.enabled = true;
        _inImage.sprite = spriteList[blockID];
    }
}
