using System.Collections;
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
        spriteList = _board.spriteList;
    }

    public void SetBlock()
    {
        if (blockID == -1)
        {
            info = Info.Mine;
            _inImage.enabled = false;
            _inImage.sprite = spriteList[9]; // Áö·Ú sprite ³Ö¾îÁÖ±â
            return;
        }

        info = Info.Number;
        _inImage.enabled = false;
        _inImage.sprite = spriteList[blockID];
    }
    
    public void OpenBlock()
    {
        // 0ÀÌ¸é ÁÖº¯ 8 ºí·Ï ¿ÀÇÂ
        /*if (blockID == 0)
        {
            for (int i = y - 1; i <= y + 1; i++)
            {
                if (i < 0 || i > 9) continue; // ¸Ê ¹þ¾î³µÀ» ¶§

                for (int j = x - 1; j <= x + 1; j++)
                {
                    if (j < 0 || j > 9) continue; // ¸Ê ¹þ¾î³µÀ» ¶§

                    
                }
            }
        }*/

        if (isOpen) return;

        if (isMarking) SetBlock();

        _inImage.enabled = true;
        isOpen = true;
    }

    public void MarkingBlock()
    {
        if (isOpen) return;

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
