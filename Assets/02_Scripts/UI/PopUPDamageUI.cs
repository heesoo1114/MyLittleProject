using UnityEngine;
using DG.Tweening;
using TMPro;

public class PopUPDamageUI : PoolAbleMono
{
    private TMPro.TextMeshPro _textMeshPro;
    Sequence mySequence;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        mySequence = DOTween.Sequence()
            .SetAutoKill(false)
            .Append(transform.DOMoveY(transform.position.y + 0.7f, 0.7f, false))
            .OnComplete(() =>
            {
                DestoryUI();
            });
    }

    void OnEnable()
    {
        mySequence.Restart();
    }

    private void DestoryUI()
    {
        // Destroy(gameObject); // 풀링으로 변경
        PoolManager.Instance.Push(this);
    }

    public override void Init()
    {
        _textMeshPro.text = UIManager.Instance.a.ToString();
    }
}
