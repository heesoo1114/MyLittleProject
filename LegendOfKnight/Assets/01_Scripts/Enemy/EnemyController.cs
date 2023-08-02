using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    CapsuleCollider _collider;
    Rigidbody _rigidbody;
    Animator _anim;

    private Transform target;
    public Transform Target
    {
        get => target;
        set => target = value;
    }

    // Move
    public float moveSpeed;
    Vector3 moveVelocity;
    public bool canChase = false; // 쫓아갈지말지

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        target = GameManager.Instance.player.transform;
    }

    void FixedUpdate()
    {
        if (Target == null) return;
        if (!canChase) return;

        Move();

        // 움직이지 않으면 바라보는 방향 또한 움직이지 않게
        if (moveVelocity.magnitude == 0) return;

        Rotate();
    }

    private void LateUpdate()
    {
        _anim.SetFloat("Move", moveVelocity.magnitude);
        // Debug.Log(moveVelocity.magnitude);
    }

    private void Move()
    {
        moveVelocity = new Vector3(target.position.x - transform.position.x, 0, target.position.z - transform.position.z).normalized * moveSpeed;
        _rigidbody.MovePosition(_rigidbody.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void Rotate()
    {
        Quaternion dirQuat = Quaternion.LookRotation(moveVelocity);
        Quaternion moveQuat = Quaternion.Slerp(_rigidbody.rotation, dirQuat, 0.25f);
        _rigidbody.MoveRotation(moveQuat);
    }

    public void AttackAnimation()
    {
        _anim.SetBool("AttackOn", true);
    }

    public void StopAttackAnimation()
    {
        _anim.SetBool("AttackOn", false);
    }

    public void DieAction()
    {
        _anim.SetTrigger("Dead");
        canChase = false;
        Invoke("RemoveObj", 1f);
    }

    public void RemoveObj()
    {
        Destroy(gameObject);
    }
}
