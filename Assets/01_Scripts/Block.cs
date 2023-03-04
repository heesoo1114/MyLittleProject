using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum Info
{
    Mine = -1,
    Number = 0,
}

public class Block : MonoBehaviour
{
    Board _board;
    Image _inImage;

    private List<Sprite> spriteList;

    public Info info = Info.Number;
    public int blockID; // -1 ~ 8

    public bool isOpen = false;
    public bool isMarking = false;

    private void Awake()
    {
        _board = transform.parent.GetComponent<Board>();
        _inImage = transform.GetChild(0).GetComponent<Image>();
        
        if (spriteList == null)
        {
            spriteList = _board.spriteList;
        }
    }

    public void SetBlock()
    {
        if (blockID == -1)
        {
            info = Info.Mine;
            _inImage.enabled = false;
            _inImage.sprite = spriteList[9]; // 지뢰 sprite 넣어주기
            return;
        }

        info = Info.Number;
        _inImage.enabled = false;
        _inImage.sprite = spriteList[blockID];
    }

    public void OpenBlock()
    {
        if (isOpen) return;

        if (isMarking) SetBlock();

        _inImage.enabled = true;
        isOpen = true;

        _board.openCount++;

        if (GameManager.Instance.isOver == false && _board.openCount >= 100 - _board.mineCount)
        {
            Debug.Log("클리어");
        }
    }

    public void MarkingBlock()
    {
        if (isOpen) return;

        // 마킹이 되어 있는 상태라면 블록을 다시 세팅해 주고 marking을 해제
        if (isMarking)
        {
            SetBlock();
            isMarking = false;
            return;
        }

        _inImage.sprite = spriteList[10];
        _inImage.enabled = true;
        isMarking = true;
    }
}
