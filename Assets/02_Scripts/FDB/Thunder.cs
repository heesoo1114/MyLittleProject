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
    }// �̰ɷ� õ�� ġ�� �ִ��� Ȯ��

    [HideInInspector] public Animator _anim;
    [HideInInspector] public Vector3 createPosition;
}
