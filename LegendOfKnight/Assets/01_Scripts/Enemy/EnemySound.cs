using UnityEngine;

public class EnemySound : AudioPlayer
{
    [SerializeField] AudioClip dieClip = null;

    public void DieSound()
    {
        PlayClip(dieClip);
    }
}
