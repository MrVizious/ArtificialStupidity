using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platform : MonoBehaviour
{
    [SerializeField]
    protected bool active;
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

}
