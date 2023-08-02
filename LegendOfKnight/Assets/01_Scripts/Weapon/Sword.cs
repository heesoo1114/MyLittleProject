using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour
{
    BoxCollider _collider; // ���� �ִ� ����
    TrailRenderer _trailRenderer; // �ܻ�

    public bool isAttaking;

    private void Awake()
    {
        _collider = GetComponentInChildren<BoxCollider>();
        _trailRenderer = GetComponentInChildren<TrailRenderer>();
    }

    public void Attack(int AttCnt)
    {
        StartCoroutine($"Attack{AttCnt}Cor");
    }

    IEnumerator Attack1Cor()
    {
        if (isAttaking) yield break;

        isAttaking = true;

        yield return new WaitForSeconds(0.4f);
        _collider.enabled = true;
        _trailRenderer.enabled = true;

        yield return new WaitForSeconds(0.2f);
        _collider.enabled = false;
        _trailRenderer.enabled = false;

        isAttaking = false;
    }

    IEnumerator Attack2Cor()
    {
        isAttaking = true;

        yield return new WaitForSeconds(0.7f);
        _collider.enabled = true;
        _trailRenderer.enabled = true;

        yield return new WaitForSeconds(0.4f);
        _collider.enabled = false;
        _trailRenderer.enabled = false;

        isAttaking = false;
    }

    public void HitEnemy(GameObject enemy)
    {
        // Enemy�� �˿� �¾��� ��
        enemy.GetComponent<EnemyController>().DieAction();
    }
}
