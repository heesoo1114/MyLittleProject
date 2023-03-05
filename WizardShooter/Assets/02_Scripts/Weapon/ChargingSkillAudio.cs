using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingSkillAudio : AudioPlayer
{
    public AudioClip _fireSkillClip;
    public AudioClip _waterSkillClip;
    public AudioClip _elecSkillClip;

    public void FireSkillSound()
    {
        PlayClip(_fireSkillClip);
    }

    public void WaterSkillSound()
    {
        PlayClip(_waterSkillClip);
    }

    public void ElecSkillSound()
    {
        PlayClip(_elecSkillClip);
    }
}
