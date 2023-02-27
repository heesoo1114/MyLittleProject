using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    // 플레이어 2인으로 key설정이 다름
    [SerializeField] private KeyCode RIGHT;
    [SerializeField] private KeyCode LEFT;
    [SerializeField] private KeyCode JUMP;
    [SerializeField] private KeyCode KICK;

    public UnityEvent<Vector2> MovementInput;
    public UnityEvent JumpInput;
    public UnityEvent KickInput;

    private void Update()
    {
        GetMovementInput();
        GetJumpInput();
        GetKickInput();
    }

    private void GetMovementInput()
    {
        Vector2 dir = Vector2.zero;

        if (Input.GetKey(RIGHT))
        {
            dir = Vector2.right;
        }
        else if (Input.GetKey(LEFT))
        {
            dir = Vector2.left;
        }

        MovementInput?.Invoke(dir);
    }

    private void GetJumpInput()
    {
        if (Input.GetKeyDown(JUMP))
        {
            JumpInput?.Invoke();
        }
    }

    private void GetKickInput()
    {
        if (Input.GetKeyDown(KICK))
        {
            KickInput?.Invoke();
        }
    }
}
