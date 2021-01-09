using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
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
            onButtonPressed.Invoke();
        }
    }
}
