using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/WEAPON/WeaponData")]
public class WeaponDataSO : ScriptableObject
{
    public BulletDataSO bulletData;

    public Sprite weaponSprite;

    [Range(0, 999)] public int ammoCapacity = 100; // ≈∫√¢ ≈©±‚
    [Range(0f, 1f)] public float shootDelay = 0.1f; // πﬂªÁ µÙ∑π¿Ã
    [Range(0f, 1f)] public float reloadDealy = 1f; // ¿Â¿¸ µÙ∑π¿Ã

    [SerializeField] private int _bulleetCount = 1; // 

    public AudioClip shootClip;
    public AudioClip noAmmoClip;
    public AudioClip reloadClip;

    public int GetBulletCountToSpawn()
    {
        return 5;
    }
}
