using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBrain : MonoBehaviour
{
    public UnityEvent<Vector2> MovementKeyPress;
    public UnityEvent<Vector2> PositionChanged;
    public UnityEvent FireButtonPress;
    public UnityEvent FireButtonRealease;

    public EnemytDataSO _enemyData;
    private EnemytDataSO EnemytDataSO
    {
        get => _enemyData;
    }

    private Transform _target; // ���߿� ���ӸŴ����� ���ؼ� ���� �� ����, ������ �� �巡�׵��
    public Transform Target
    {
        get => _target;
    }

    [SerializeField] private Transform _basePosition;
    public Transform BasePosition { get => _basePosition; }

    private void Start()
    {
        _target = GameManager.Instance.PlayerPosition;
    }

    private void Update()
    {
        GetPositionChangedInput();
        GetMovementKeyPress();
    }

    public void TryAttack()
    {
        FireButtonPress?.Invoke();
    }

    public void StopAttack()
    {
        FireButtonRealease?.Invoke();
    }

    private void GetMovementKeyPress()
    {
        Vector2 direction = Target.position - transform.position;
        direction = direction.normalized;
        MovementKeyPress?.Invoke(direction);
    }

    private void GetPositionChangedInput()
    {
        Vector2 plPosition = _target.position;
        PositionChanged.Invoke(plPosition);
    }

}
