using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputModifier : MonoBehaviour
{
    public bool debug;
    protected ActivationMethod activationMethod;

    protected void Start()
    {
        activationMethod = GetComponent<ActivationMethod>();
    }
    public abstract void OnButtonDown();
    public abstract void OnButtonUp();
}
