using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    protected Animator _animator;

    protected readonly int _walkHash = Animator.StringToHash("Walk");
    protected readonly int _deathHash = Animator.StringToHash("isDeath");
    protected readonly int _attakHash = Animator.StringToHash("Attack");

    private SpriteRenderer _spriteRenderer;

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void GetHitColorChanged()
    {
        _spriteRenderer.color = Color.black;
        StartCoroutine(ColorReset());
    }

    IEnumerator ColorReset()
    {
        yield return new WaitForSeconds(0.07f);
        _spriteRenderer.color = Color.white;
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
