using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerController _playerController;
    Camera _cam;

    [SerializeField] private LayerMask layermask; // Ground만 설정하여 mousePosition

    public float moveSpeed = 5f;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _cam = Camera.main;
    }

    private void Update()
    {
        PlayerMove();
        GetMouseInput();
    }

    private void GetMouseInput()
    {
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layermask))
        {
            Vector3 point = raycastHit.point;
            _playerController.LookAt(point);
        }
    }

    private void PlayerMove()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        Vector3 moveVelocity = new Vector3(xInput, 0, zInput).normalized * moveSpeed;

        _playerController.Move(moveVelocity);
    }
}
