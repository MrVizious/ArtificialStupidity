#if (UNITY_EDITOR) 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Button))]
public class AIInputRecorder : MonoBehaviour
{
    public bool debug = false;
    public string recordingName;

    [SerializeField]
    private bool recording = false;
    private InputManager input;
    private List<ActionPair> actions;
    private AIInputsRecording recordingObject;

    private float lastHorizontalInput = 0;
    private float currentRecordingTime = 0f;

    private void Start()
    {
        input = GetComponent<InputManager>();
        actions = new List<ActionPair>();
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

        recordingObject.actions = new List<AIAction>();
        recordingObject.times = new List<float>();
        foreach (ActionPair pair in actions)
        {
            recordingObject.actions.Add(pair.action);
            recordingObject.times.Add(pair.time);
        }
        if (debug) Debug.Log("Number of data in " + recordingName +
         " " + recordingObject.actions.Count);

        string path = "Assets/Recordings/AI/" + recordingName + ".asset";
        AssetDatabase.CreateAsset(recordingObject, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    private void RecordAction(AIAction newAction, float time)
    {
        if (debug) Debug.Log(newAction.ToString() + " recorded at: " + time + " seconds");
        actions.Add(
            new ActionPair(newAction, time)
        );
    }
}

#endif