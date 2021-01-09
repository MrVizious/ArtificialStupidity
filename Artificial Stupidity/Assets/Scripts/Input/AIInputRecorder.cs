using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;


public class AIInputRecorder : MonoBehaviour
{
    public bool debug = false;
    public string recordingName;

    private bool recording;
    private InputManager input;
    private List<KeyValuePair<AIAction, float>> actions;
    private AIInputsRecording recordingObject;

    private float lastHorizontalInput = 0;
    private float currentRecordingTime = 0f;

    private void Start()
    {
        input = GetComponent<InputManager>();
        actions = new List<KeyValuePair<AIAction, float>>();
        if (recordingName == null || recordingName == "")
        {
            string sceneName = SceneManager.GetActiveScene().name;
            if (debug) Debug.Log("Name for recording changed to " + sceneName);
            recordingName = sceneName;
        }
    }

    void Update()
    {
        if (recording)
        {
            currentRecordingTime += Time.deltaTime;
            if (input.jumpButtonDown)
            {
                RecordAction(AIAction.Jump, currentRecordingTime);
            }
            else if (input.horizontalInput != lastHorizontalInput)
            {
                lastHorizontalInput = input.horizontalInput;
                if (input.horizontalInput > 0) RecordAction(AIAction.RunForward, currentRecordingTime);
                else if (input.horizontalInput < 0) RecordAction(AIAction.RunBackward, currentRecordingTime);
                else RecordAction(AIAction.StopRunning, currentRecordingTime);
            }
        }
    }

    public void ToggleRecording()
    {
        if (!recording)
        {
            if (debug) Debug.Log("STARTED recording called: " + recordingName);
            currentRecordingTime = 0f;
            InitializeScriptableObject();
            recording = true;
        }
        else
        {
            if (debug) Debug.Log("STOPPED recording called: " + recordingName);
            WriteToScriptableObjectFile();
            recording = false;
        }
    }

    private void InitializeScriptableObject()
    {
        recordingObject = ScriptableObject.CreateInstance<AIInputsRecording>();
    }

    private void WriteToScriptableObjectFile()
    {
        if (debug) Debug.Log("Writing recording with name " + recordingName + " to scriptable object");

        recordingObject.actions = actions;

        string path = "Assets/Recordings/" + recordingName + ".asset";
        AssetDatabase.CreateAsset(recordingObject, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        if (debug)
        {
            foreach (KeyValuePair<AIAction, float> pair in recordingObject.actions)
            {
                Debug.Log(pair.Key + " at " + pair.Value);
            }
        }
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
