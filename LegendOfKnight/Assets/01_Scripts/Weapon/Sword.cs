using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour
{
    BoxCollider _collider; // 꺼져 있는 상태
    TrailRenderer _trailRenderer; // 잔상

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
        // Enemy가 검에 맞았을 때
        enemy.GetComponent<EnemyController>().DieAction();
    }
}
