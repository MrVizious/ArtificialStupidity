using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputManager : MonoBehaviour
{
    public Dictionary<KeyCode, bool> keyCodesDown;
    public bool jumpButtonDown = false;
    public int horizontalInput = 0;

    public void AddKeyCode(KeyCode newKey)
    {
        if (!keyCodesDown.ContainsKey(newKey))
        {
            keyCodesDown.Add(newKey, false);
        }
    }

    protected bool UpdateJumpButtonDown()
    {
        jumpButtonDown = Input.GetButtonDown("Jump");
        return jumpButtonDown;
    }

    protected int UpdateHorizontalInput()
    {
        horizontalInput = (int)Input.GetAxisRaw("Horizontal");
        return horizontalInput;
    }

    protected void UpdateKeyCodesDown()
    {
        foreach (KeyValuePair<KeyCode, bool> pair in keyCodesDown)
        {
            keyCodesDown[pair.Key] = Input.GetKeyDown(pair.Key);
        }
    }
}