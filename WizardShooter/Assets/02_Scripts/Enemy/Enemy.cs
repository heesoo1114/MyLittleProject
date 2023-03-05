using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : PoolAbleMono
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

    private bool _isDelayAttack = true; // fire ��ų 1�ʿ� �� ���� �� ���� 
    private bool _isDelayAttack2 = true; // elec ��ų 1�ʿ� �� ���� �� ���� 

    private ObjMovement _movement;

    private CapsuleCollider2D _capsuleCollider;

    private void Awake()
    {
        _brain = GetComponent<EnemyBrain>();
        _movement = GetComponent<ObjMovement>();
        _capsuleCollider = transform.Find("Colider").GetComponent<CapsuleCollider2D>();

        Init();
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
        // Destroy(gameObject); // ���߿� Ǯ������ ����
        PoolManager.Instance.Push(this);
    }

    public void OnEnemyDie()
    {
        EnemyDieEvent?.Invoke();
        Invoke("Die", 0.32f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) // �Ϲ� bullet
        {
            GetHit();
            Bullet _bullet = collision.gameObject.GetComponent<Bullet>();
            _bullet.BulletDestory();
            enemyHealth -= _bullet.BulletData.damage;
            GameManager.Instance._playerHp.PlayerVampire(_bullet.BulletData.damage);
            UIManager.Instance.ShowingDamagePopUp?.Invoke(_bullet.BulletData.damage, _brain.UIPosition.transform);

            if (enemyHealth <= 0)
            {
                OnEnemyDie();
                return;
            }
        }

        if (collision.gameObject.CompareTag("IcicleBullet")) // ��帧 ��ų
        {
            GetHit();
            Bullet _bullet = collision.gameObject.GetComponent<Bullet>();
            _bullet.BulletDestory();
            enemyHealth -= _bullet.BulletData.damage;
            GameManager.Instance._playerHp.PlayerVampire(_bullet.BulletData.damage);
            UIManager.Instance.ShowingDamagePopUp?.Invoke(_bullet.BulletData.damage, _brain.UIPosition.transform);

            // icicle �¾��� �� ��� ���߰� �ƹ� �ൿ�� ���� �� ��
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

                if(distance < 2.5 && _isDelayAttack2 == true)
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
            GameManager.Instance._playerHp.PlayerVampire(2);
            UIManager.Instance.ShowingDamagePopUp?.Invoke(2, _brain.UIPosition.transform);

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
        enemyHealth -= 7;
        GameManager.Instance._playerHp.PlayerVampire(8);
        UIManager.Instance.ShowingDamagePopUp?.Invoke(7, _brain.UIPosition.transform);
        _movement._objSpeed = 0.5f; // ���� enemy speed ����ٰ� 

        if (enemyHealth <= 0)
        {
            OnEnemyDie();
        }

        yield return new WaitForSeconds(4);
        _isDelayAttack2 = true;
        _movement._objSpeed = _movement._movementSO.maxSpeed; // 4�� �ڿ� �ٽ� ���󺹱� 
        StopCoroutine(ElecSkillHit());
    }

    public override void Init()
    {
        _brain.enabled = true;
        enemyHealth = _brain._enemyData.maxHealth;
        _capsuleCollider.enabled = true;
    }
}
