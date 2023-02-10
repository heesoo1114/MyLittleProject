using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bigger : MonoBehaviour 
{
    private Vector3 _startSIze;
    [SerializeField] private Vector3 _endSIze;
    [SerializeField] private float _resizeTime;

    CircleCollider2D _circleCollider;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        /*if (transform.localScale.x >= 27)
        {
            Debug.Log("localScale is size 27");
            _circleCollider.enabled = true;
        }
        else
        {
            _circleCollider.enabled = false;
        }*/
    }

    private IEnumerator Start()
    {
        _startSIze = transform.localScale;

        while (true)
        {
            yield return StartCoroutine(Resize(_startSIze, _endSIze, _resizeTime));
            yield return StartCoroutine(Resize(_endSIze, _startSIze, _resizeTime));
        }
    }

    private IEnumerator Resize(Vector3 start, Vector3 end, float time)
    {
        float current = 0;
        float percent = 0;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / time;

            transform.localScale = Vector3.Lerp(start, end, percent);

            yield return null;
        }
    }
}