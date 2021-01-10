using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Collider2D))]
public class EphimeralPlatform : Platform
{
    private Collider2D col;
    private Bounds bounds;

    protected override void Start()
    {
        base.Start();
        col = GetComponent<Collider2D>();
        col.enabled = true;
        bounds = col.bounds;

        ChangeColor(new Color(40, 40, 140));

        UpdatePlatform();
    }
    public override bool ToggleActive()
    {
        if (isActive()) Deactivate();
        else Activate();
        return isActive();
    }

    public override void Activate()
    {
        if (CanActivate())
        {
            active = true;
            UpdatePlatform();
        }
    }

    public override void Deactivate()
    {
        active = false;
        UpdatePlatform();
    }
    private void UpdatePlatform()
    {
        col.enabled = active;
        Color tempColor = spriteRenderer.color;
        tempColor.a = active ? 1.0f : 0.6f;
        spriteRenderer.color = tempColor;
    }

    private bool CanActivate()
    {
        if (bounds.Contains(LevelManager.AI.transform.position))
        {
            return false;
        }
        return true;
    }
}