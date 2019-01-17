using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class StickmanDebugging : MonoBehaviour
{

    public bool xSpeed;
    public bool ySpeed;
    public bool jumpButtonPressed;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame

    void Update()
    {
        //Debug of x speed
        if(xSpeed) Debug.Log("x speed: " + rb.velocity.x);

        //Debug of y speed
        if(ySpeed) Debug.Log("y speed: " + rb.velocity.y);

        //Debug of jump button pressed
        if(jumpButtonPressed && Input.GetButtonDown("Jump"))Debug.Log("Jump Button Pressed");
    }
}
