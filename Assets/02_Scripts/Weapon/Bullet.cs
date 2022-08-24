using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    protected float _timeToLive;

    [SerializeField]
    protected BulletDataSO _bulletData;
    public BulletDataSO BulletData
    {
        get => _bulletData;
        set => _bulletData = value;
    }

    protected bool _isEnemy;
    public bool IsEnemy
    {
        get => _isEnemy;
        set => _isEnemy = value;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetPositionAndRotation(Vector3 position, Quaternion rot)
    {
        transform.SetPositionAndRotation(position, rot);
    }

    private void FixedUpdate()
    {
        _timeToLive += Time.fixedDeltaTime;
        _rigidbody.MovePosition(transform.position + _bulletData.bulletSpeed * transform.right * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            BulletDestory(); // 나중에 풀링으로 변경
        }

        if(collision.gameObject.CompareTag("Portal"))
        {
            EnemySpawner _enemySpawner = collision.gameObject.GetComponent<EnemySpawner>();
            if(_enemySpawner.SpawnerCanDie == true)
            {
                BulletDestory();
                _enemySpawner.PortalHealth -= 2;
                _enemySpawner.GetHit();

                if(_enemySpawner.PortalHealth <= 0)
                {
                    _enemySpawner.PortalDie?.Invoke();
                }
            }
        }
    }

    public void BulletDestory()
    {
        Destroy(gameObject);
    }

}
