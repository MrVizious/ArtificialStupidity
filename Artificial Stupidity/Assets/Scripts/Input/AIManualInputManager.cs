using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManualInputManager : InputManager
{
    private void Update()
    {
        // Updates everything

        // For manual movement
        UpdateHorizontalInput();
        UpdateJumpButtonDown();

        // For starting and stopping recording
        UpdateKeyCodesUpAndDown();
    }
}
