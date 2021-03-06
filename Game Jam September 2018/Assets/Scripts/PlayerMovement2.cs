﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour {

    Rigidbody2D physics;
    Transform transform;

    public float moveSpeed = 1;
    public float jumpForce = 10;

    float moveDiv = 10;
    bool isGrounded = true;

	// Use this for initialization
	void Start () {
        physics = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();

        physics.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector2(Input.GetAxis("Horizontal") * moveSpeed / moveDiv, 0));

        jump();

        Debug.DrawRay(transform.position, Vector2.down);
    }

    void jump() {
        if (Input.GetKeyDown("w") && isGrounded) {
            physics.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Entered");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log("Exited");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
