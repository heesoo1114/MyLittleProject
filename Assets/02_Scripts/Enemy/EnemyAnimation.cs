using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    protected Animator _animator;

    protected readonly int _walkHash = Animator.StringToHash("Walk");
    protected readonly int _deathHash = Animator.StringToHash("isDeath");
    protected readonly int _attakHash = Animator.StringToHash("Attack");

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void WalkAnimation(bool value)
    {
        _animator.SetBool(_walkHash, value);
    }

    public void AnimatePlayer(float velocity)
    {
        WalkAnimation(velocity > 0);
    }

    public void AttackAnimation()
    {
        _animator.SetBool(_attakHash, true);
    }

    public void StopAttackAnimation()
    {
        _animator.SetBool(_attakHash, false);
    }

    public virtual void DeadAnimation()
    {
        _animator.SetTrigger(_deathHash);
    }
}
