using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;
    private float rayCastLength = 0.005f;
    private float width;
    private float height;
    private float jumpPressTime;
    private float maxJumpTime = 0.2f;
    public bool facingRight = true;
    bool isJumping = false;
    
    private Rigidbody2D rb;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        Vector2 vect = rb.velocity;
        rb.velocity = new Vector2(horizontalMove * moveSpeed, vect.y);
        if ((horizontalMove > 0 && !facingRight) || (horizontalMove < 0 && facingRight))
        {
            FlipPlayer();
        }
        float verticalMove = Input.GetAxis("Jump");
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnBecameInvisible()
    {
        Debug.Log("Fell off the map");
        //Destroy(gameObject);
    }

    public bool IsOnGround()
    {
        bool groundCheck1 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - height), -Vector2.up, rayCastLength);
        bool groundCheck2 = Physics2D.Raycast(new Vector2(transform.position.x + (width - 0.2f), transform.position.y - height), -Vector2.up, rayCastLength);
        bool groundCheck3 = Physics2D.Raycast(new Vector2(transform.position.x - (width - 0.2f), transform.position.y - height), -Vector2.up, rayCastLength);
        return (groundCheck1 || groundCheck2 || groundCheck3);
    }
}
