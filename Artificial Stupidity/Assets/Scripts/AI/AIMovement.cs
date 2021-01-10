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
    public float groundCheckDistance = 0.15f;
    public LayerMask groundLayerMask;


    private InputManager input;
    private Rigidbody2D rb;
    [SerializeField]
    private bool grounded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // In case the layermask is not set, Gorund is a good default
        if (groundLayerMask == 0) groundLayerMask = 1 << LayerMask.NameToLayer("Ground");


        // Change where to get the input from
        switch (controlMode)
        {
            case ControlMode.Automatic:
                InputManager temp = GetComponent<AIAutomaticInputManager>();
                if (temp == null)
                {
                    input = gameObject.AddComponent<AIAutomaticInputManager>();
                }
                else
                {
                    input = temp;
                }
                break;

            case ControlMode.Manual:
                temp = GetComponent<AIManualInputManager>();
                if (temp == null)
                {
                    input = gameObject.AddComponent<AIManualInputManager>();
                }
                else
                {
                    input = temp;
                }
                break;
        }
    }

    private void Update()
    {
        UpdateGrounded();
        Move();
    }

    /// <summary>
    /// Updates movement. Jumps and moves horizontally
    /// </summary>
    private void Move()
    {
        // Only jump if touching ground
        if (grounded && input.jumpButtonDown)
        {
            grounded = false;
            rb.velocity += Vector2.up * jumpSpeed;
            if (debug) Debug.Log("Jumped");
        }
        //Update horizontal speed
        rb.velocity = new Vector2(input.horizontalInput * horizontalSpeed, rb.velocity.y);
    }

    /// <summary>
    /// Checks if the AI is touching ground underneath
    /// </summary>
    /// <returns>True if grounded, false if not</returns>
    private bool UpdateGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,
                                             -Vector2.up,
                                             groundCheckDistance,
                                             groundLayerMask
                                            );

        if (hit.collider != null)
        {
            grounded = true;
        }
        else grounded = false;
        return grounded;
    }
}
