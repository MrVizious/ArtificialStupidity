using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivationMethod : MonoBehaviour
{
    protected Platform platform;

    protected void Start()
    {
        platform = GetComponent<Platform>();
    }
    public abstract void OnButtonDown();
    public abstract void OnButtonUp();
}
