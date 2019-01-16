using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Debugging : MonoBehaviour
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
        if(xSpeed) Debug.Log("x speed: " + rb.velocity.x);
        if(ySpeed) Debug.Log("y speed: " + rb.velocity.y);
        if(jumpButtonPressed && Input.GetButtonDown("Jump"))Debug.Log("Jump Button Pressed");
    }
}
