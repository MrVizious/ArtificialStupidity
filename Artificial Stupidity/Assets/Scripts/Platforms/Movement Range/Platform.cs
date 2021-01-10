using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Platform : MonoBehaviour
{
    public bool debug = false;

    [SerializeField]
    protected bool active;
    protected SpriteRenderer spriteRenderer;

    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public bool isActive()
    {
        return active;
    }

    /// <summary>
    /// Toggles the active state of the platform
    /// </summary>
    /// <returns>State of the platform after the toggle</returns>
    public abstract bool ToggleActive();

    /// <summary>
    /// Activates the platform
    /// </summary>
    public abstract void Activate();

    /// <summary>
    /// Deactivates the platform
    /// </summary>
    public abstract void Deactivate();

    protected void ChangeColor(Color newColor)
    {
        spriteRenderer.color = newColor;
    }
}
