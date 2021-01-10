using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTapInputModifier : InputModifier
{
    public int numberOfTaps = 3;
    public float maxTimeBetweenTaps = 0.25f;

    [SerializeField]
    private int currentNumberOfTaps = 0;
    private IEnumerator tapTimer;

    public override void OnButtonDown()
    {
        currentNumberOfTaps++;
        if (currentNumberOfTaps >= numberOfTaps)
        {
            activationMethod.OnButtonDown();
            if (tapTimer != null)
            {
                StopCoroutine(tapTimer);
                tapTimer = null;
            }
        }
        else
        {

            if (tapTimer != null)
            {
                StopCoroutine(tapTimer);
                tapTimer = null;
            }

            tapTimer = TapTimer();
            StartCoroutine(tapTimer);
        }


    }

    public override void OnButtonUp()
    {
        if (currentNumberOfTaps >= numberOfTaps)
        {
            currentNumberOfTaps = 0;
            activationMethod.OnButtonUp();
        }

    }

    private IEnumerator TapTimer()
    {
        yield return new WaitForSeconds(maxTimeBetweenTaps);
        currentNumberOfTaps = 0;
        tapTimer = null;
    }
}
