using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ActivationMethod : MonoBehaviour
{
    public Image button;
    protected Platform platform;

    protected virtual void Start()
    {
        platform = GetComponent<Platform>();
    }
    public abstract void OnButtonDown();
    public abstract void OnButtonUp();

    protected void ChangeButtonColor(Color newColor)
    {
        button.color = newColor;
    }
}
