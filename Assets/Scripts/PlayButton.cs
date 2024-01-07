using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private readonly int sceneIndex = 1;

    public void Play()
    {
        Debug.Log($"SceneManager.LoadScene({sceneIndex})");
    }
}
