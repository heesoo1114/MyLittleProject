using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Camera _cam;

    PlayerController _playerController;
    GunController _gunController;

    [SerializeField] private LayerMask layermask; // Ground만 설정하여 mousePosition

    public float moveSpeed = 5f;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _gunController = GetComponentInChildren<GunController>();
        _cam = Camera.main;
    }

    private void Update()
    {
        GetMoveInput();
        GetMouseInput();
        GetFireInput();
    }

    private void GetFireInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _gunController.FireBullet(); 
        }
    }

    private void GetMouseInput()
    {
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layermask))
        {
            Vector3 point = raycastHit.point;
            _playerController.LookAt(point);
            // Debug.DrawLine(ray.origin, point);
        }
    }

    private void GetMoveInput()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        Vector3 moveVelocity = new Vector3(xInput, 0, zInput).normalized * moveSpeed;

        _playerController.Move(moveVelocity);
    }
}
