using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void AnimPlay(string parameter)
    {
        _anim.SetBool(parameter, true);
        StartCoroutine(DelayAnim(parameter));
    }

    IEnumerator DelayAnim(string parameter)
    {
        yield return new WaitForSeconds(0.3f);
        AnimStop(parameter);
    }

    public void AnimStop(string parameter)
    {
        _anim.SetBool(parameter, false);
    }
}
