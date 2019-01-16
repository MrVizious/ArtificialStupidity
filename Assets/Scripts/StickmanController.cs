using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class StickmanController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float max_x_Speed;
    public float max_y_Speed;
    public float jumpForce;

    [SerializeField]
    private bool grounded;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        grounded = false;
    }


    void Update(){
        if(Input.GetButtonDown("Jump") && grounded){
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime, -max_x_Speed, max_x_Speed), Mathf.Clamp(rb.velocity.y, -max_y_Speed, max_y_Speed));
    }

    void OnCollisionStay2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag.Equals("Ground") && collisionInfo.otherCollider.gameObject.tag.Equals("Player")) grounded = true;
        //Debug.Log("Collider de objeto: " + collisionInfo.otherCollider.gameObject.tag + " contra collider de tag: " + collisionInfo.gameObject.tag);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag.Equals("Ground") && collisionInfo.otherCollider.gameObject.tag.Equals("Player")) grounded = true;
        //Debug.Log("Collider de objeto: " + collisionInfo.otherCollider.gameObject.tag + " contra collider de tag: " + collisionInfo.gameObject.tag);
    }

    void OnCollisionExit2D(Collision2D collisionInfo){
        if(collisionInfo.gameObject.tag.Equals("Ground") && collisionInfo.otherCollider.gameObject.tag.Equals("Player")) grounded = false;
    }
}
