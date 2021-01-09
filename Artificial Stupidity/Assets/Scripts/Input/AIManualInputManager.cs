using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManualInputManager : InputManager
{
    private void Update()
    {
        // Only updates horizontal input and jump button
        UpdateHorizontalInput();
        UpdateJumpButtonDown();
    }
}
