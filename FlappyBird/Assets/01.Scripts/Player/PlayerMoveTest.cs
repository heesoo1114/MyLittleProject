using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMoveTest : MonoBehaviour
{
    public UnityEvent<Vector3> OnMovementKeyPress;

    private void Update()
    {
        GetMovementKey();
    }

    public void GetMovementKey()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(x, y, 0);

        // ���� ���� input���� OnMovementKeyPress�� �Ű������� �����ֱ�

    }
}
