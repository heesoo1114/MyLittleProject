using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public UnityEvent EnemyDieEvent;
    public UnityEvent EnemyGetHitEvent;

    private EnemyBrain _brain;
    public int enemyHealth;
    private int EnemyHealth
    {
        get => enemyHealth;
        set => enemyHealth = value;
    }

    private Weapon _weapon;
    private Weapon Weapon
    {
        get => _weapon;
        set => _weapon = value;
    }

    private bool _isDelayAttack = true; // fire 스킬 1초에 한 번씩 딜 들어가게 
    private bool _isDelayAttack2 = true; // elec 스킬 1초에 한 번씩 딜 들어가게 

    private ObjMovement _movement;

    private void Awake()
    {
        _brain = GetComponent<EnemyBrain>();
        _movement = GetComponent<ObjMovement>();
    }

    private void Start()
    {
        enemyHealth = _brain._enemyData.maxHealth;
        _weapon = GameManager.Instance._weapon;
    }

    private void Update()
    {
        PlayerSkillGetHit();
    }

    public void GetHit()
    {
        EnemyGetHitEvent?.Invoke();
    }

    public void Die()
    {
        Destroy(gameObject); // 나중에 풀링으로 변경
    }

    public void OnEnemyDie()
    {
        EnemyDieEvent?.Invoke();
        Invoke("Die", 0.32f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) // 일반 bullet
        {
            GetHit();
            Bullet _bullet = collision.gameObject.GetComponent<Bullet>();
            _bullet.BulletDestory();
            enemyHealth -= _bullet.BulletData.damage;

            if (enemyHealth <= 0)
            {
                OnEnemyDie();
                return;
            }
        }

        if (collision.gameObject.CompareTag("IcicleBullet")) // 고드름 스킬
        {
            GetHit();
            Bullet _bullet = collision.gameObject.GetComponent<Bullet>();
            _bullet.BulletDestory();
            enemyHealth -= _bullet.BulletData.damage;

            // icicle 맞았을 때 즉시 멈추고 아무 행동을 하지 못 함
            _movement.StopImmediatelly();
            _brain.enabled = false;

            if (enemyHealth <= 0)
            {
                OnEnemyDie();
            }
        }
    }

    private void PlayerSkillGetHit()
    {
        if(_weapon.AnySkillRunning == true)
        {
            if(_weapon.FireSkillRunning == true)
            {
                float distance = Vector2.Distance(_brain.BasePosition.position, GameManager.Instance.PlayerPosition.position);

                if(distance < 2.63 && _isDelayAttack == true)
                {
                    HitFireSkill();
                }
            }
            if(GameManager.Instance._thunder.OnThunder == true)
            {
                float distance = Vector2.Distance(_brain.BasePosition.position, GameManager.Instance.ChargingSkillSystem._position);

                if(distance < 3.3 && _isDelayAttack2 == true)
                {
                    HitElecSkill();
                }
            }
        }
    }

    public void HitFireSkill()
    {
        _isDelayAttack = false;
        StartCoroutine(FireSkillHit());
    }

    IEnumerator FireSkillHit()
    {
        for(int i = 0; i < 5; i++)
        {
            GetHit();
            EnemyHealth -= 2;

            if (enemyHealth <= 0)
            {
                OnEnemyDie();
            }

            yield return new WaitForSeconds(1);
        }
        _isDelayAttack2 = false;
        StopCoroutine(FireSkillHit());
    }

    public void HitElecSkill()
    {
        _isDelayAttack2 = false;
        StartCoroutine(ElecSkillHit());
    }

    IEnumerator ElecSkillHit()
    {
        GetHit();
        enemyHealth -= 10;
        _movement._objSpeed = 0.5f; // 맞은 enemy speed 낮췄다가 

        if (enemyHealth <= 0)
        {
            OnEnemyDie();
        }

        yield return new WaitForSeconds(4);
        _isDelayAttack2 = true;
        _movement._objSpeed = _movement._movementSO.maxSpeed; // 4초 뒤에 다시 원상복귀 
        StopCoroutine(ElecSkillHit());
    }
}
