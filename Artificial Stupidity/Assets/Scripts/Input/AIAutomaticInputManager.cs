using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAutomaticInputManager : InputManager
{
    public AIInputsRecording recording;
    private int currentPairIndex = 0;
    public void StartPlayback()
    {

    }

    private void NextAction()
    {
        if (currentPairIndex + 1 < recording.actions.Count)
        {
            currentPairIndex++;
        }
    }
}
