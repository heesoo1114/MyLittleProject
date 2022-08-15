using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/WEAPON/WeaponData")]
public class WeaponDataSO : ScriptableObject
{
    public BulletDataSO bulletData;

    [Range(0f, 1f)] public float shootDelay = 0.1f; // 발사 딜레이
    [Range(0f, 1f)] public float reloadDealy = 1f; // 장전 딜레이

    [SerializeField] private int _bulleetCount = 1; // 

    public AudioClip shootClip;
    public AudioClip noAmmoClip;
    public AudioClip reloadClip;

    public int GetBulletCountToSpawn()
    {
        return 5;
    }
}
