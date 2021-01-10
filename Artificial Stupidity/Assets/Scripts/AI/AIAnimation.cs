using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimation : MonoBehaviour
{
    private Animator animator;
    private InputManager input;
    private AIMovement movement;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        input = GetComponent<InputManager>();
        movement = GetComponent<AIMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        animator.SetBool("Grounded", movement.grounded);
        animator.SetFloat("HorizontalInput", input.horizontalInput);
        if (input.horizontalInput > 0f)
        {
            spriteRenderer.flipX = false;
        }
        else if (input.horizontalInput < 0f)
        {

            spriteRenderer.flipX = true;
        }

    }
}