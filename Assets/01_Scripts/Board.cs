using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject blockPrefab;

    int[,] boardInfo = new int[10, 10];

    public int mineCount = 10; // ���ڰ���

    public List<Sprite> spriteList;

    private void Start()
    {
        InitBoard();
        IntantiateBoard();
        DebugBoardInfo();
    }

    [ContextMenu("�ʱ�ȭ")]
    public void InitBoard()
    {
        // 2���� �迭 ���� 0(�⺻ ��)���� �ʱ�ȭ
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                boardInfo[y, x] = 0;
            }
        }

        // ���� �־��ֱ�
        for (int i = 0; i < mineCount;)
        {
            // �ƹ� �迭 ���� ����
            int x = Random.Range(0, 10); // 0 ~ 9 �� ������ �� ��ȯ
            int y = Random.Range(0, 10); // 0 ~ 9 �� ������ �� ��ȯ

            // �迭�� �� �κ��� ���� -1(����) �־��ֱ�
            if (boardInfo[y, x] == 0)
            {
                boardInfo[y, x] = -1;
                i++;
            }
        }

        // �⺻ �� �ֺ� ���� �� ã�� �ڽſ��� ���� �ο�
        int number = 0;
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                if (boardInfo[y, x] == -1) continue; // ������ ��

                for (int i = y - 1; i <= y + 1; i++)
                {
                    if (i < 0 || i > 9) continue; // �� ����� ��

                    for (int j = x - 1; j <= x + 1; j++)
                    {
                        if (j < 0 || j > 9) continue; // �� ����� ��

                        if (boardInfo[i, j] == -1) // ������ ��
                        {
                            number++;
                        }
                    }
                }

                boardInfo[y, x] = number;
                number = 0;
            }
        }
    }

    [ContextMenu("����")]
    public void IntantiateBoard()
    {
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                GameObject block = Instantiate(blockPrefab, this.gameObject.transform);
                block.name = "Block" + (y * 10 + (x + 1)); // ��� �̸� 
                
                Block _block = block.GetComponent<Block>();
                
                _block.blockID = boardInfo[y, x]; // ��Ͽ� ���� �־���
                _block.SetBlock();
            }
        }
    }

    [ContextMenu("�����")]
    public void DebugBoardInfo()
    {
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                Debug.Log(boardInfo[y, x]);
            }
        }
    }
}
