using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1.0f;
    }

    public void ToMain()
    {
        LoadingSceneManager.LoadScene("Main");
    }

    public void ToPlay()
    {
        LoadingSceneManager.LoadScene("Play");
    }

    public void ToExit()
    {
        Application.Quit();
    }
}
