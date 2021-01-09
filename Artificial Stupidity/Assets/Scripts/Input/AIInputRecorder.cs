using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInputRecorder : InputManager
{
    public enum AIAction
    {
        Jump,
        RunForward,
        RunBackward,
        StopRunning
    }
    public bool recording;
    public string recordingName;


    private List<KeyValuePair<AIAction, float>> actions;
    private float lastHorizontalInput = 0;
    private float currentRecordingTime = 0f;

    void Start()
    {
        actions = new List<KeyValuePair<AIAction, float>>();
    }

    void Update()
    {
        UpdateKeyCodesDown();
        if (recording)
        {
            currentRecordingTime += Time.deltaTime;
            if (UpdateJumpButtonDown())
            {
                RecordAction(AIAction.Jump, currentRecordingTime);
            }
            else if (UpdateHorizontalInput() != lastHorizontalInput)
            {
                lastHorizontalInput = horizontalInput;
                if (horizontalInput > 0) RecordAction(AIAction.RunForward, currentRecordingTime);
                else if (horizontalInput < 0) RecordAction(AIAction.RunBackward, currentRecordingTime);
                else RecordAction(AIAction.StopRunning, currentRecordingTime);
            }
        }
    }

    public void ToggleRecording()
    {
        if (!recording)
        {
            if (debug) Debug.Log("Started recording called: " + recordingName);
            currentRecordingTime = 0f;
            recording = true;
        }
        else
        {
            if (debug) Debug.Log("STOPPED recording called: " + recordingName);
            WriteRecordingToCSV();
            recording = false;
        }
    }

    private void WriteRecordingToCSV()
    {
        if (debug) Debug.Log("Writing recording with name " + recordingName + " to CSV");
        //TODO: Record to CSV
    }

    private void RecordAction(AIAction newAction, float time)
    {
        if (debug) Debug.Log(newAction.ToString() + " recorded at: " + time + " seconds");
        actions.Add(
            new KeyValuePair<AIAction, float>
            (newAction, time)
        );
    }
}
