using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent OnJumptKeyEvent;

    private void Update()
    {
        GetJumpKeyInput();
    }

    public void GetJumpKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJumptKeyEvent?.Invoke();
        }
    }
}
