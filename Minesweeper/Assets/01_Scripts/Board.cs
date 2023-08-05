using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Block blockPrefab;

    int[,] boardInfo = new int[10, 10];

    public int mineCount = 0; // ���ڰ��� 0�� 100�� �����ϰ� �� ����
    public int openCount = 0; // ���� Ŭ��� ���� count

    public List<Sprite> spriteList;

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

    public void InstantiateBoard()
    {
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                Block block = Instantiate(blockPrefab, gameObject.transform);

                block.name = (y * 10 + (x + 1)).ToString(); // ��� �̸� 
                block.blockID = boardInfo[y, x]; // ��Ͽ� ���� �־���

                block.SetBlock();
            }
        }
    }

    public void RemoveBoard()
    {
        for (int i = 0; i < 100; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public void OpenBoard()
    {
        for (int i = 0; i < 100; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<Block>().OpenBlock();
        }

        GameManager.Instance.isOver = true;
    }

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
