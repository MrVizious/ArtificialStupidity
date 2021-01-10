using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : InputManager
{
    private void Update()
    {
        // Only updates the specific keys needed
        UpdateKeyCodesUpAndDown();
    }
}
