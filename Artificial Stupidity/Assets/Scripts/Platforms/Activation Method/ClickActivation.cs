using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickActivation : ActivationMethod
{
    public override void OnButtonDown()
    {
        platform.ToggleActive();
    }
    public override void OnButtonUp()
    {
    }

}
