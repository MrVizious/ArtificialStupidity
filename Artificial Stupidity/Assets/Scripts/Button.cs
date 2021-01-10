using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public bool debug = false;
    public KeyCode key;
    public UnityEvent onButtonPressed;

    private InputManager input;

    void Start()
    {
        input = GetComponent<InputManager>();
        input.AddKeyCode(key);
    }

    void Update()
    {
        if (input.keyCodesDown[key])
        {
            if (debug) Debug.Log("Key " + key.ToString() + " pressed");
            onButtonPressed.Invoke();
        }
    }
}
