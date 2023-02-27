using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rigid;

    public float speed;

    public float jumpPower;
    public bool canJump = true;

    public GameObject joint;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    public void PlayerMove(Vector2 dir)
    {
        _rigid.velocity = dir.normalized * speed; 
    }

    public void PlayerJump()
    {
        if (!canJump) return;
        StartCoroutine(JumpCor());
    }

    IEnumerator JumpCor()
    {
        _rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.01f);

        canJump = false;
    }

    public void PlayerKick()
    {
        StartCoroutine(KickCor());
    }

    IEnumerator KickCor()
    {
        joint.transform.rotation = Quaternion.Euler(0f, 0f, 90);

        yield return new WaitForSeconds(0.2f);

        joint.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") && !(canJump))
        {
            canJump = true;
        }
    }
}
