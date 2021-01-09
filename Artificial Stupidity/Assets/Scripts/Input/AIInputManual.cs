using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInputManual : InputManager
{
    private void Update()
    {
        UpdateHorizontalInput();
        UpdateJumpButtonDown();
    }
}
