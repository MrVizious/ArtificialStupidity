using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayInputModifier : InputModifier
{
    public float secondsOfDelay = 1.5f;

    public override void OnButtonDown()
    {
        StartCoroutine(DelayedButtonDown());
    }
    public override void OnButtonUp()
    {
        StartCoroutine(DelayedButtonUp());
    }

    private IEnumerator DelayedButtonDown()
    {
        yield return new WaitForSeconds(secondsOfDelay);
        activationMethod.OnButtonDown();
    }
    private IEnumerator DelayedButtonUp()
    {
        yield return new WaitForSeconds(secondsOfDelay);
        activationMethod.OnButtonUp();
    }
}
