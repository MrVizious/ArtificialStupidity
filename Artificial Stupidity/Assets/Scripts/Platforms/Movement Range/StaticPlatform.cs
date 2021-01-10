using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPlatform : Platform
{
    public override bool ToggleActive()
    {
        return isActive();
    }

    public override void Activate() { }

    public override void Deactivate() { }
}
