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
public class AIInputsRecording : ScriptableObject
{
    public List<KeyValuePair<AIAction, float>> actions;

}
