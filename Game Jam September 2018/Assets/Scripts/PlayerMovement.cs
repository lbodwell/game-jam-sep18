using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D physics;
    Transform transform;

    public float moveSpeed = 2;
    public float jumpForce = 5;

    float moveDiv = 10;

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
	}

    void jump() {

        if (Input.GetKeyDown("w")) {
            physics.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    /*bool IsGrounded () {
        RaycastHit2D cast = Physics2D.Raycast(transform.position, Vector2.down);

        cast.
    }*/
}
