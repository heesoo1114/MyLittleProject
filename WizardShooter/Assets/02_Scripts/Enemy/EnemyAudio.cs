using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : AudioPlayer
{
    public AudioClip _deathClip;

    public void DieClip()
    {
        PlayClip(_deathClip);
    }
}
