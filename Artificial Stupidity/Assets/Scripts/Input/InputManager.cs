using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputManager : MonoBehaviour
{
    // If true, shows debugging log on unity console
    public bool debug = false;

    // Keeps which of the requested keys have been pressed down
    public Dictionary<KeyCode, bool> keyCodesDown;

    [HideInInspector]
    // True is the jump button was pressed this frame
    public bool jumpButtonDown = false;

    [HideInInspector]
    // -1, 0 or 1 depending on the horizontal trajectory of the AI
    public int horizontalInput = 0;

    /// <summary>
    /// Adds a key to keep track of to the InputManager script
    /// </summary>
    /// <param name="newKey">KeyCode to keep track of</param>
    public void AddKeyCode(KeyCode newKey)
    {
        if (keyCodesDown == null)
        {
            if (debug) Debug.Log("KeyCodesDown was not initialized, doing now");
            keyCodesDown = new Dictionary<KeyCode, bool>();
        }
        // Checks that it doesn't already exist in the of keys list to keep track of
        if (!keyCodesDown.ContainsKey(newKey))
        {
            // If it isn't tracked, the key is added and set to false
            if (debug) Debug.Log("Adding key " + newKey.ToString() + " to KeyCodeDown");
            keyCodesDown.Add(newKey, false);
        }
    }

    /// <summary>
    /// Updates the variable that indicates if the jump button was pressed
    /// on this frame
    /// </summary>
    /// <returns>New value asigned to jumpButtonDown</returns>
    protected bool UpdateJumpButtonDown()
    {
        jumpButtonDown = Input.GetButtonDown("Jump");
        return jumpButtonDown;
    }

    /// <summary>
    /// Updates the variable that keeps track of the horizontal direction inputed
    /// </summary>
    /// <returns>New value of horizontalInput</returns>
    protected int UpdateHorizontalInput()
    {
        horizontalInput = (int)Input.GetAxisRaw("Horizontal");
        return horizontalInput;
    }

    /// <summary>
    /// Updates the bool values of the keys that are being kept track of. If 
    /// the key was pressed in that frame, it is true, if not, it is false
    /// </summary>
    protected void UpdateKeyCodesDown()
    {
        if (keyCodesDown == null)
        {
            if (debug) Debug.Log("KeyCodesDown was not initialized, doing now");
            keyCodesDown = new Dictionary<KeyCode, bool>();
        }
        List<KeyCode> keycodes = new List<KeyCode>(keyCodesDown.Keys);
        foreach (KeyCode key in keycodes)
        {
            keyCodesDown[key] = Input.GetKeyDown(key);
        }
    }
}