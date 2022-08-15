using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/WEAPON/BulletData")]
public class BulletDataSO : ScriptableObject
{
    public GameObject bulletPrefab;
    [Range(1, 10)] public int damage = 1;
    [Range(1, 100)] public float bulletSpeed = 1;

    public GameObject impactObstacle; // ��ֹ��� �ε����� ���� ȿ��
    public GameObject impactEnemy; // �÷��̾ �ε����� ���� ȿ��
}
