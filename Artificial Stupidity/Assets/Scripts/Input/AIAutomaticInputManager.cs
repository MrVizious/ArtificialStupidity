using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class AIAutomaticInputManager : InputManager
{
    public AIInputsRecording data;

    [SerializeField]
    private bool playing = false;
    private int currentPairIndex = 0;
    [SerializeField]
    private float currentTime = 0f;

    private void Update()
    {
        UpdateKeyCodesUpAndDown();

        if (playing)
        {
            // We have to reset the jump button since our recording data does't
            jumpButtonDown = false;
            currentTime += Time.deltaTime;
            if (data.actions == null) Debug.Log("Data is NULL");
            else if (data.actions.Count == 0) Debug.Log("Data is EMPTY");
            else if (currentTime >= data.times[currentPairIndex])
            {
                switch (data.actions[currentPairIndex])
                {
                    case AIAction.Jump:
                        jumpButtonDown = true;
                        break;
                    case AIAction.RunForward:
                        horizontalInput = 1;
                        break;
                    case AIAction.StopRunning:
                        horizontalInput = 0;
                        break;
                    case AIAction.RunBackward:
                        horizontalInput = -1;
                        break;
                }
                if (debug) Debug.Log(
                                 data.actions[currentPairIndex].ToString()
                                 + " performed");

                NextAction();
            }
        }
    }

    public void TogglePlayback()
    {
        if (!playing)
        {
            StartPlayback();
        }
        else
        {
            StopPlayback();
        }
    }

    public void StartPlayback()
    {
        if (debug) Debug.Log("STARTING Playback!");
        playing = true;
        currentPairIndex = 0;
        currentTime = 0f;
    }

    public void StopPlayback()
    {
        if (debug) Debug.Log("STOPPING Playback!");
        playing = false;
        currentPairIndex = 0;
        currentTime = 0f;
    }

    private void NextAction()
    {
        if (currentPairIndex + 1 < data.actions.Count)
        {
            if (debug) Debug.Log("Next action!");
            currentPairIndex++;
        }
        else
        {
            if (debug) Debug.Log("No action left!");
        }
    }
}
