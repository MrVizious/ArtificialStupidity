/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class StickmanController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float maxSpeed;
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        Debug.Log("Input in Horizontal axis is: " + Input.GetAxis("Horizontal"));
    }

    void FixedUpdate(){
        rb.AddForce(Vector2.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }
}
