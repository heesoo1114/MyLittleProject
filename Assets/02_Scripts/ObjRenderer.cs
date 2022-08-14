using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRenderer : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // �� �Լ��� PointerPositionChange�� ����
    public void FaceDirection(Vector2 pointerInput)
    {
        Vector3 direction = (Vector3)pointerInput - transform.position;
        Vector3 result = Vector3.Cross(Vector2.up, direction);

        _spriteRenderer.flipX = result.z > 0;
    }
}
