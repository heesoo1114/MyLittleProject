using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SettingSoundManager : MonoBehaviour
{
    [SerializeField] private GameObject _soundpopup;
    private RectTransform a;
    private bool _isMove = false;
    private bool _isToggle = true;
    [SerializeField] private float timeSpeed = 0.7f;

    private void Awake()
    {
        a = GetComponent<RectTransform>();
    }

    #region PauseMove
    public void PauseMove()
    {
        if(_isMove)
        {
            return;
        }

        if(_isToggle)
        {
            PauseMenuMove(-600);
        }
        else
        {
            PauseMenuMove(600);
        }
    }

    private void PauseMenuMove(int index)
    {
        _isMove = true;

        Sequence sqe = DOTween.Sequence();
        sqe.Append(a.DOAnchorPosY(a.anchoredPosition.y + index, timeSpeed));
        sqe.OnComplete(() =>
        {
            switch(index)
            {
                case -600: _isToggle = false;
                    break;
                case 600: _isToggle = true;
                    break;
            }
        });
    }
    #endregion 
}
