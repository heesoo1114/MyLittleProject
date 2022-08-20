using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    [HideInInspector] public Vector3 MousePosition;
    [HideInInspector] public Vector3 TranPosition;
    [HideInInspector] public Vector3 CreatePosition;

    [HideInInspector] public Vector3 CursorPosition;
    [HideInInspector] public Vector3 Trans2Position;

    private void Update()
    {
        MpToCp();
    }

    public void MpToCp()
    {
        MousePosition = Input.mousePosition;
        Trans2Position = Camera.main.ScreenToWorldPoint(MousePosition);
        CursorPosition = Trans2Position;
    }

    public void CalMpToCp()
    {
        MousePosition = Input.mousePosition;
        TranPosition = Camera.main.ScreenToWorldPoint(MousePosition);
        CreatePosition = new Vector3(TranPosition.x, TranPosition.y + 1.8f, 0);
    }
}
