using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class EphimeralPlatform : Platform
{
    private Collider2D col;
    private SpriteRenderer spriteRenderer;
    private Bounds bounds;

    private void Start()
    {
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        col.enabled = true;
        bounds = col.bounds;

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