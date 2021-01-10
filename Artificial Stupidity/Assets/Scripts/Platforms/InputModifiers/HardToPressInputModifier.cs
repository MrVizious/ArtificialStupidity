using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardToPressInputModifier : InputModifier
{
    public float secondsToPress = 3f;
    private IEnumerator pressingDownCoroutine;

    public override void OnButtonDown()
    {
        if (pressingDownCoroutine == null)
        {
            pressingDownCoroutine = PressingDownCoroutine();
            StartCoroutine(pressingDownCoroutine);
        }
    }

    public override void OnButtonUp()
    {
        if (pressingDownCoroutine == null) activationMethod.OnButtonUp();
        else
        {
            StopCoroutine(pressingDownCoroutine);
            pressingDownCoroutine = null;
        }

    }

    private IEnumerator PressingDownCoroutine()
    {
        yield return new WaitForSeconds(secondsToPress);
        activationMethod.OnButtonDown();
        pressingDownCoroutine = null;
    }

}
