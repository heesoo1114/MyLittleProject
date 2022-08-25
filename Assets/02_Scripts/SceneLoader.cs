using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ToMain()
    {
        LoadingSceneManager.LoadScene("Main");
    }

    public void ToPlay()
    {
        LoadingSceneManager.LoadScene("Play");
    }
}
