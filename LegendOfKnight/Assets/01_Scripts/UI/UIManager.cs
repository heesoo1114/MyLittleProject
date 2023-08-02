using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI waveTxt;

    public GameObject overPanel;

    public void OverPanelOut()
    {
        overPanel.SetActive(true);
    }

    public void GetWaveCount(int waveCount)
    {
        waveTxt.text = $"WAVE {waveCount}";
    }

    public void TimeScaleDown()
    {
        Time.timeScale = 0;
    }

    public void TimeScaleUp()
    {
        Time.timeScale = 1;
    }

    public void Play()
    {
        SceneManager.LoadScene("Play");
    }

    public void Main()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
