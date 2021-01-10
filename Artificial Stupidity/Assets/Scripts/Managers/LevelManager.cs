using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static GameObject AI;

    private void Start()
    {
        AI = GameObject.Find("AutomaticAI");
        if (AI == null) AI = GameObject.Find("RecordingAI");
        StartLevel();
    }

    public static void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void StartLevel()
    {

    }
}
