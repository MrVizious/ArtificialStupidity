using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AIMovement : MonoBehaviour
{
    public enum ControlMode
    {
        Automatic,
        Manual
    }

    public ControlMode controlMode;
    public float speed = 3f;


    private InputManager input;

    private void Start()
    {
        switch (controlMode)
        {
            case ControlMode.Automatic:
                break;
            case ControlMode.Manual:
                input = GetComponent<AIInputManual>();
                break;
        }
    }
}
