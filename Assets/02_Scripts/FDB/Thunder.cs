using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
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
    [HideInInspector] public Vector3 createPosition;
}
