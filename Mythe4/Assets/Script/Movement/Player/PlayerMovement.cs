using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveForward;
    float moveSide;
    float moveUp;

    public float speed = 2.6f;
    public float jumpSpeed = 7f;

    Rigidbody rig;

    bool isGrounded;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveForward = Input.GetAxis("Vertical") * speed;
        moveSide = Input.GetAxis("Horizontal") * speed;
        moveUp = Input.GetAxis("Jump") * jumpSpeed;

        rig.velocity = (transform.forward * moveForward) + (transform.right * moveSide) + (transform.up * rig.velocity.y);

        if(isGrounded && moveUp != 0)
        {
            rig.AddForce(transform.up * moveUp, ForceMode.VelocityChange);
            isGrounded = false;
        }
        if(speed <= 0)
        {
            speed = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        isGrounded = false;
    }
}