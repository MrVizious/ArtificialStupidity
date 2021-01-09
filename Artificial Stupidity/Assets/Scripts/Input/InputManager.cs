using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputManager : MonoBehaviour
{
    public bool debug = false;
    public Dictionary<KeyCode, bool> keyCodesDown;

    [HideInInspector]
    public bool jumpButtonDown = false;
    [HideInInspector]
    public int horizontalInput = 0;

    public void AddKeyCode(KeyCode newKey)
    {
        if (keyCodesDown == null)
        {
            if (debug) Debug.Log("KeyCodesDown was not initiated, creating it...");
            keyCodesDown = new Dictionary<KeyCode, bool>();
        }
        if (!keyCodesDown.ContainsKey(newKey))
        {
            if (debug) Debug.Log("Adding key " + newKey.ToString() + " to KeyCodeDown");
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
        List<KeyCode> keycodes = new List<KeyCode>(keyCodesDown.Keys);
        foreach (KeyCode key in keycodes)
        {
            keyCodesDown[key] = Input.GetKeyDown(key);
        }
    }
}