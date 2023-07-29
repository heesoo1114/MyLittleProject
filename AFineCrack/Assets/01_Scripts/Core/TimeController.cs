using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeController : MonoBehaviour
{
    public static TimeController Instance;

    private void Awake()
    {
        Instance = this; // ���� �ڵ�  ����
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    public void ResertTimeScale()
    {
        StopAllCoroutines();
        Time.timeScale = 1.0f;
    }

    public void ModifyTimeScale(float targetValue, float timeToWait, Action OnComplete = null)
    {
        StartCoroutine(TimeScaleCoroutine(targetValue, timeToWait, OnComplete));
    }

    // 0.05�� �ִٰ� Ÿ�ӽ��� 0.2�� ����߷���, () => �ٽ� �ڷ�ƾ�� ������Ѽ� 0.2���Ŀ� 1�� ��������
    IEnumerator TimeScaleCoroutine(float targetValue, float timeToWait, Action OnComplete = null)
    {
        yield return new WaitForSecondsRealtime(timeToWait); // �̳༮�� Ÿ�ӽ����Ͽ� ������ ���� �ʴ´�.
        Time.timeScale = targetValue;
        OnComplete?.Invoke();
    }
}
