using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;

public enum State
{ 
    UP, // 하나의 꼭짓점이 위를 바라보고 있을 때
    DOWN // 하나의 꼭짓점이 아래를 바라보고 있을 때
}


public class PlayerController : MonoBehaviour
{
    public State state = State.UP;
    public List<Pivot> pivotList; // 처음 위, 오른쪽, 왼쪽 꼭짓점순
    public GameObject sprite;

    private int firstIndex = 0;
    private int middleIndex = 1;
    private int lastIndex = 2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            sprite.transform.parent = pivotList[lastIndex].gameObject.transform;
            pivotList[lastIndex].Roatate();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (state == State.UP) 
            {
                pivotList[firstIndex].Roatate(); 

                state = State.DOWN;

                GoLastIndex(firstIndex);

                sprite.transform.parent = pivotList[lastIndex].gameObject.transform;
            }
            else if (state == State.DOWN)
            {
                pivotList[lastIndex].Roatate();

                state = State.UP;

                GoFirstIndex(lastIndex);

                sprite.transform.parent = pivotList[firstIndex].gameObject.transform;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Roatate2();
        }
    }

    public void GoFirstIndex(int index)
    {
        SwapIndex(index, 0);
    }

    public void GoLastIndex(int index)
    {
        SwapIndex(index, pivotList.Count - 1);
    }

    public void SwapIndex(int nowIndex, int changeIndex)
    {
        Pivot temp = pivotList[nowIndex];
        pivotList[nowIndex] = pivotList[changeIndex];
        pivotList[changeIndex] = temp;
    }
}