using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDownActivation : ActivationMethod
{
    public override void OnButtonDown()
    {
        platform.ToggleActive();
    }
    public override void OnButtonUp()
    {
        platform.ToggleActive();
    }
}
