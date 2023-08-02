using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    TextMeshProUGUI _tmp;

    private int currentScore;

    private void Awake()
    {
        _tmp = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateScoreText()
    {
        currentScore += 10;
        _tmp.text = "Life: " + currentScore;
    }
}
