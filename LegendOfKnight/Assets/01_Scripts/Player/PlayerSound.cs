using UnityEngine;

public class PlayerSound : AudioPlayer
{
    [SerializeField]
    private AudioClip hurtClip = null;

    [SerializeField]
    private AudioClip attack1Clip = null;

    [SerializeField]
    private AudioClip attack2Clip = null;

    public void HurtSound()
    {
        PlayClipwithVariablePitch(hurtClip);
    }

    public void AttackSound(int attCnt)
    {
        AudioClip temp = (attCnt == 1) ? attack1Clip : attack2Clip;
        PlayClipwithVariablePitch(temp);
    }
}
