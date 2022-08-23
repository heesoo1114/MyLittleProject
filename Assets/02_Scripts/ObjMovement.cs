using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjMovement : MonoBehaviour
{
    [SerializeField]
    public MovementDataSO _movementSO;

    private Rigidbody2D _rigidbody;

    protected float _currentVelocity = 0;
    protected Vector2 _movementDirection;

    public UnityEvent<float> OnVelocityChange;

    [HideInInspector] public float _objSpeed;
    private float ObjSpeed
    {
        get => _objSpeed;
        set => _objSpeed = value;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _objSpeed = _movementSO.maxSpeed;
    }

    public void MoveAgent(Vector2 moveInput)
    {
        // _movementDirection = moveInput.normalized * 5f;

        // Ű�� ������ ��
        if (moveInput.sqrMagnitude > 0)
        {
            // ���� ����, ����
            if (Vector2.Dot(moveInput, _movementDirection) < 0)
            {
                _currentVelocity = 0;
            }
            _movementDirection = moveInput.normalized;
        }
        _currentVelocity = CalculateSpeed(moveInput);
    }

    private float CalculateSpeed(Vector2 moveInput)
    {
        if (moveInput.sqrMagnitude > 0)
        {
            _currentVelocity += _movementSO.acceleration * Time.deltaTime;
        }
        else
        {
            _currentVelocity -= _movementSO.deAcceleration * Time.deltaTime;
        }

        return Mathf.Clamp(_currentVelocity, 0, ObjSpeed);
    }

    private void FixedUpdate()
    {
        OnVelocityChange?.Invoke(_currentVelocity);
        _rigidbody.velocity = _movementDirection * _currentVelocity;
    }

    public void StopImmediatelly()
    {
        _currentVelocity = 0;
        _rigidbody.velocity = Vector2.zero;
    }

}
