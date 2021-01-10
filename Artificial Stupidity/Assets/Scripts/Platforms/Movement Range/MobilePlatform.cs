using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class MobilePlatform : Platform
{
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    [Range(0f, 1f)]
    public float startPercentage = 0f;
    public float speed = 3f;
    private float distanceTravelled = 0f;
    protected override void Start()
    {
        base.Start();
        ChangeColor(new Color(0.15f, 0.55f, 0.15f, 1.0f));
        distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
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
