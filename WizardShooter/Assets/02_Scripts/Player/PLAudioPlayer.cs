using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAudioPlayer : AudioPlayer
{
    [SerializeField]
    protected AudioClip _stepClip;
    public AudioClip _gethitClip;

    public void PlayStepSound()
    {
        PlayClipwithVariablePitch(_stepClip);
    }

    public void GetHitSound()
    {
        PlayClip(_gethitClip);
    }
}
