using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public LevelsData levelsData;

    private void Start()
    {
        for (int i = 0; i < levelsData.levels.Count; i++)
        {
            levelsData.levels[i] = new LevelsData.LevelData(
                false,
                levelsData.levels[i].audio
            );
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level_01");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

}
