using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : PoolAbleMono
{
    public float damage = 10f;
    public float delayTime = 2f;

    public bool _onThunder = false;
    public bool OnThunder
    {
        get => _onThunder;
        set => _onThunder = value;
    }// 이걸로 천둥 치고 있는지 확인

    [HideInInspector] public Animator _anim;
    private Vector3 _createPosition;
    [HideInInspector] public Vector3 CreatePosition
    {
        get => _createPosition;
        set => _createPosition = value;
    }

    private void Awake()
    {
        Init();
    }

    public override void Init()
    {
        
    }
}
