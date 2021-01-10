using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public bool debug = false;
    public LevelsData levelsData;
    public static GameObject AI;

    private AudioSource audioSource;
    private GameObject input;

    private void Start()
    {
        AI = GameObject.Find("AutomaticAI");
        if (AI == null) AI = GameObject.Find("RecordingAI");
        int index = SceneManager.GetActiveScene().buildIndex - 1;
        if (debug) Debug.Log("Index is " + index);
        if (!levelsData.levels[index].listened)
        {
            if (debug) Debug.Log("Playing audio");
            DisableInput();
            audioSource = GetComponent<AudioSource>();
            AudioClip clip = levelsData.levels[index].audio;
            if (debug) Debug.Log("Audio clip is: " + clip.name);
            PlayAudio(clip);
            levelsData.levels[index] =
                new LevelsData.LevelData(true, clip);
        }
    }

    public static void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void PlayAudio(AudioClip clip)
    {
        if (debug) Debug.Log("Trying to play " + clip.name);
        audioSource.PlayOneShot(clip);
        StartCoroutine(CheckAudioHasFinishedCoroutine());
    }

    private IEnumerator CheckAudioHasFinishedCoroutine()
    {
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        EnableInput();
    }
    private void DisableInput()
    {
        input = GameObject.Find("PlayerInput");
        input.SetActive(false);
    }

    private void EnableInput()
    {

        input.SetActive(true);
    }

}
