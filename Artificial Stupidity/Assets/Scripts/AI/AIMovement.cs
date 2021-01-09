using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AIMovement : MonoBehaviour
{
    public enum ControlMode
    {
        Automatic,
        Manual
    }

    public bool debug = false;
    public ControlMode controlMode;
    public float horizontalSpeed = 3f;
    public float jumpSpeed = 5f;
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayerMask;


    private InputManager input;
    private Rigidbody2D rb;
    [SerializeField]
    private bool grounded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        switch (controlMode)
        {
            case ControlMode.Automatic:
                break;
            case ControlMode.Manual:
                input = GetComponent<AIInputManual>();
                break;
        }
    }

    private void Update()
    {
        UpdateGrounded();
        switch (controlMode)
        {
            case ControlMode.Automatic:
                break;
            case ControlMode.Manual:
                UpdateManual();
                break;
        }
    }

    private void UpdateManual()
    {
        if (grounded && input.jumpButtonDown)
        {
            grounded = false;
            rb.velocity += Vector2.up * jumpSpeed;
            if (debug) Debug.Log("Jumped");
        }
        rb.velocity = new Vector2(input.horizontalInput * horizontalSpeed, rb.velocity.y);
    }

    private bool UpdateGrounded()
    {
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            -Vector2.up,
            groundCheckDistance,
            groundLayerMask);

        // If it hits something...
        if (hit.collider != null)
        {
            grounded = true;
        }
        else grounded = false;
        return grounded;
    }
}
