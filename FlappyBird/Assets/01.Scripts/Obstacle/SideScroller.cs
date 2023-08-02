using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScroller : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    public float moveSpeed;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        Vector2 offset = new Vector2(moveSpeed * Time.time, 0);
        _meshRenderer.material.mainTextureOffset = offset;
    }
}
