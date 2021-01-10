using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedDurationActivation : ActivationMethod
{
    public float secondsOfDuration;
    private IEnumerator fixedDurationCoroutine;
    public override void OnButtonDown()
    {
        if (fixedDurationCoroutine == null)
        {
            fixedDurationCoroutine = FixedDurationCoroutine();
            StartCoroutine(fixedDurationCoroutine);
        }
    }
    public override void OnButtonUp()
    {
    }

    private IEnumerator FixedDurationCoroutine()
    {
        platform.ToggleActive();
        yield return new WaitForSeconds(secondsOfDuration);
        platform.ToggleActive();
        fixedDurationCoroutine = null;
    }
}
