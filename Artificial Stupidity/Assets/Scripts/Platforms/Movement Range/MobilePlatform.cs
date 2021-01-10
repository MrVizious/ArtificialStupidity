using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class MobilePlatform : Platform
{
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 3f;
    private float distanceTravelled = 0f;
    protected override void Start()
    {
        ChangeColor(new Color(40, 140, 40));
    }
    private void Update()
    {
        if (active)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);

        }
    }

    public override bool ToggleActive()
    {
        if (isActive()) Deactivate();
        else Activate();
        return isActive();
    }

    public override void Activate()
    {
        active = true;
    }

    public override void Deactivate()
    {
        active = false;
    }
}
