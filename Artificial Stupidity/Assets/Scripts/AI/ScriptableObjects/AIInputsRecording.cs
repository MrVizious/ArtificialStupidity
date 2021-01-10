using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIAction
{
    Jump,
    RunForward,
    RunBackward,
    StopRunning
}
public struct ActionPair
{
    public AIAction action;
    public float time;
    public ActionPair(AIAction newAction, float newTime)
    {
        action = newAction;
        time = newTime;
    }
}
public class AIInputsRecording : ScriptableObject
{
    public List<AIAction> actions;
    public List<float> times;
}
