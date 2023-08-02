using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerController _playerController;

    // ��ġ
    private float clickTime;
    private bool isClick;
    public float minClickTime = 1;

    // ���� �޺�
    [Header("Attack")]
    public float attackCickTime;
    public float maxAttackClickTime = 0.3f;
    public int attackCount = 0;
    public bool startAttack;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (isClick)
        {
            clickTime += Time.deltaTime;
            if (clickTime >= minClickTime)
            {
                print("�� ������ ��");
                TouchDown();
            }
        }
        else
        {
            clickTime = 0;
        }

        #region ���� �޺�
        if (startAttack)
        {
            attackCickTime += Time.deltaTime;

            if (attackCickTime > maxAttackClickTime)
            {
                attackCount = 0;
                startAttack = false;
                // _playerController.isAttack = false;
                _playerController.ChangeState(PlayerState.Normal);
            }
        }
        else
        {
            attackCickTime = 0;
        }
        #endregion
    }

    public void ButtonDown()
    {
        isClick = true;
    }

    public void ButtonUp()
    {
        isClick = false;
        // Debug.Log(clickTime);

        if (clickTime >= minClickTime)
        {
            print("�� ������ ��");
            TouchUp();
        }
        else
        {
            print("��ġ");
            Touch();
        }
    }

    private void Touch()
    {
        attackCount++;
        startAttack = true;

        // _playerController.isAttack = true;
        _playerController.ChangeState(PlayerState.Attack);
        _playerController.AttackReady(attackCount);
    }

    private void TouchDown()
    {
        _playerController.ParryingReady();
        _playerController.ChangeState(PlayerState.Shield);
    }

    private void TouchUp()
    {
        _playerController.Parrying();
        _playerController.ChangeState(PlayerState.Normal);
    }
}
