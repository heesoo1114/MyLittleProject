using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAnimation : MonoBehaviour
{
    protected Animator _animator;

    protected readonly int _walkHash = Animator.StringToHash("Walk");
    protected readonly int _deathHash = Animator.StringToHash("Death");

    private SpriteRenderer _spriteRenderer;

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void GetHitColor()
    {
        _spriteRenderer.color = Color.red;
        StartCoroutine(ColorReset());
    }

    IEnumerator ColorReset()
    {
        yield return new WaitForSeconds(0.7f);
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

    public virtual void DeadAnimation()
    {
        _animator.SetTrigger(_deathHash);
    }
}
