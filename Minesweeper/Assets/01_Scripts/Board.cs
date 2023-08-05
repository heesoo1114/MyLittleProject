using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Block blockPrefab;

    int[,] boardInfo = new int[10, 10];

    public int mineCount = 0; // 지뢰개수 0과 100을 제외하고 다 가능
    public int openCount = 0; // 게임 클리어를 위한 count

    public List<Sprite> spriteList;

    public void InitBoard()
    {
        // 2차원 배열 전부 0(기본 땅)으로 초기화
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                boardInfo[y, x] = 0;
            }
        }

        // 지뢰 넣어주기
        for (int i = 0; i < mineCount;)
        {
            // 아무 배열 랜덤 지정
            int x = Random.Range(0, 10); // 0 ~ 9 중 랜덤한 값 반환
            int y = Random.Range(0, 10); // 0 ~ 9 중 랜덤한 값 반환

            // 배열이 빈 부분일 때만 -1(지뢰) 넣어주기
            if (boardInfo[y, x] == 0)
            {
                boardInfo[y, x] = -1;
                i++;
            }
        }

        // 기본 땅 주변 지뢰 수 찾고 자신에게 숫자 부여
        int number = 0;
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                if (boardInfo[y, x] == -1) continue; // 지뢰일 때

                for (int i = y - 1; i <= y + 1; i++)
                {
                    if (i < 0 || i > 9) continue; // 맵 벗어났을 때

                    for (int j = x - 1; j <= x + 1; j++)
                    {
                        if (j < 0 || j > 9) continue; // 맵 벗어났을 때

                        if (boardInfo[i, j] == -1) // 지뢰일 때
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

                block.name = (y * 10 + (x + 1)).ToString(); // 블록 이름 
                block.blockID = boardInfo[y, x]; // 블록에 정보 넣어줌

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
