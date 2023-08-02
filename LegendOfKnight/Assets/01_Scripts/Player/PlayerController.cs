using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Normal, // Idle, Run
    Attack, // 공격중
    Shield // 방어중
}

public class PlayerController : MonoBehaviour
{
    public PlayerState currentState;

    Player _player;

    Rigidbody _rigidbody;
    Animator _anim;

    Sword _sword;
    Shield _shield;

    // 이동
    [Header("Move")]
    [SerializeField] private FixedJoystick joy;
    Vector3 moveVelocity;
    public float moveSpeed;

    // 무기
    [Header("Fight")]
    [SerializeField] private GameObject swrod;
    [SerializeField] private GameObject shield;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _sword = swrod.GetComponent<Sword>();
        _shield = shield.GetComponent<Shield>();
        _player = GetComponent<Player>();
    }

    private void Start()
    {
        currentState = PlayerState.Normal;

        // Rotate 초기화
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    void FixedUpdate()
    {
        if (_player.isDead) return;
        if (currentState == PlayerState.Attack) return;

        Move();

        // 움직이지 않으면 바라보는 방향 또한 움직이지 않게
        if (moveVelocity.sqrMagnitude == 0) return;
        
        Rotate();
    }

    void LateUpdate()
    {
        _anim.SetFloat("Move", moveVelocity.sqrMagnitude);
    }

    public void ChangeState(PlayerState ChangeState)
    {
        currentState = ChangeState;
    }

    private void Move()
    {
        float xInput = joy.Horizontal;
        float zInput = joy.Vertical;

        // float xInput = Input.GetAxisRaw("Horizontal");
        // float zInput = Input.GetAxisRaw("Vertical");

        moveVelocity = new Vector3(-xInput, 0, -zInput).normalized * moveSpeed;
        _rigidbody.MovePosition(_rigidbody.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void Rotate()
    {
        Quaternion dirQuat = Quaternion.LookRotation(moveVelocity);
        Quaternion moveQuat = Quaternion.Slerp(_rigidbody.rotation, dirQuat, 0.25f);
        _rigidbody.MoveRotation(moveQuat);
    }

    public void AttackReady(int AttCnt)
    {
        if (currentState == PlayerState.Shield) return;

        _anim.SetTrigger("AttackOn");
        _sword.Attack(AttCnt);
    }

    public void ParryingReady()
    {
        if (currentState == PlayerState.Shield) return;
        if (currentState == PlayerState.Attack) return;

        _anim.SetBool("ShieldOn", true);
        _shield.ParryingReady(true);
    }

    public void Parrying()
    {
        _anim.SetBool("ShieldOn", false);
        _shield.Parrying();
    }

    public void DieAnimation()
    {
        _anim.SetTrigger("Dead");
    }

    public void GetHitAnimation()
    {
        _anim.SetTrigger("GetHit");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            // 플레이어와 적이 닿았을 때
            if (currentState == PlayerState.Shield) return;
            _player.GetDamage(10);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemySword"))
        {
            if (currentState == PlayerState.Shield)
            {
                return;
            }

            if (_shield.isParrying)
            {
                // 적 데미지 들어가기
                other.GetComponent<EnemyController>().DieAction();
                return;
            }

            _player.GetDamage(10);
        }
    }
}
