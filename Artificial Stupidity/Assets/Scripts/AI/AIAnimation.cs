using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimation : MonoBehaviour
{
    private Animator animator;
    private InputManager input;
    private AIMovement movement;
    private SpriteRenderer renderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        input = GetComponent<InputManager>();
        movement = GetComponent<AIMovement>();
        renderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        animator.SetBool("Grounded", movement.grounded);
        animator.SetFloat("HorizontalInput", input.horizontalInput);
        if (input.horizontalInput > 0f)
        {
            renderer.flipX = false;
        }
        else if (input.horizontalInput < 0f)
        {

            renderer.flipX = true;
        }

    }
}
