using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticePanelUI : PoolAbleMono
{
    private Image _image;
    private Text _text;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _text = GetComponentInChildren<Text>();
    }

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void DestroyUI()
    {
        Destroy(gameObject); // 풀링으로 변경
        // PoolManager.Instance.Push(this);
    }

    public IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(0.5f);
        Color color = _image.color;
        Color _color = _text.color;
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime / 1f;
            _color.a -= Time.deltaTime / 1f;
            _image.color = color;
            _text.color = _color;
            yield return null;
        }
        // gameObject.SetActive(false);
        DestroyUI();
    }

    public override void Init()
    {
   
    }
}
