using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDownActivation : ActivationMethod
{
    protected override void Start()
    {
        base.Start();
        ChangeButtonColor(new Color(0.55f, 0.15f, 0.55f, 1f));
    }
    public override void OnButtonDown()
    {
        platform.ToggleActive();
    }
    public override void OnButtonUp()
    {
        platform.ToggleActive();
    }
}
