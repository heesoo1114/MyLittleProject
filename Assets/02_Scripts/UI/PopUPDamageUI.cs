using System.Collections;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class PopUPDamageUI : PoolAbleMono
{
    private TMPro.TextMeshPro _textMeshPro;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        Sequence mySequence = DOTween.Sequence()
        .Append(transform.DOMoveY(transform.position.y + 0.5f, 1f, false))
        .OnStart(() =>
        {
            StartCoroutine(FadeIn());
        })
        .OnComplete(() =>
        {
            DestoryUI();
        });
    }

    private IEnumerator FadeIn()
    {
        Color color = _textMeshPro.color;
        while (color.a > 0f)
        {
            yield return new WaitForSeconds(0.001f);
            color.a -= Time.deltaTime / 1f;
            _textMeshPro.color = color;
        }
    }

    private void DestoryUI()
    {
        // Destroy(gameObject); // Ǯ������ ����
        PoolManager.Instance.Push(this);
    }

    public override void Init()
    {

    }
}
