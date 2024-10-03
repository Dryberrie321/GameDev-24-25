using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private float horizontal;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 6;
    [SerializeField] private float castDistance;
    [SerializeField] Vector2 boxSize;
    public LayerMask ground;


    private float coyoteTimeCounter = 0.16f;
    private float coyoteTime;
    private float jumpTimeCounter = 0.7f;
    private float jumpTime;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        sidewaysMovement();
        jump();
        groundCheck();
    }
    void sidewaysMovement()
    {
        horizontal = Input.GetAxis("Horizontal");
    }
    public bool groundCheck()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, ground))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void jump()
    {
        if (Input.GetKeyDown("space") && groundCheck())
        {
            executeJump();
        }

        // coyote time calculations
                // ability for player to jump even if they are no longer grounded for a short peroid of time after being in the air
                // more forgiving jump mechanics
            if (groundCheck() == true)
            {
                coyoteTime = coyoteTimeCounter;
            }
            else
            {
                coyoteTime -= Time.deltaTime;
            }

            if (Input.GetKeyDown("space") && (groundCheck() == false))
            {
                jumpTime = jumpTimeCounter;
            }
            else
            {
                jumpTime -= Time.deltaTime;
            }

            if ((coyoteTime >= 0.0f) && (coyoteTime != coyoteTimeCounter) && (Input.GetKeyDown("space")))
            {
                executeJump();
            }

            if ((jumpTime >= 0.0f) && (jumpTime != jumpTimeCounter) && (groundCheck() == true) && rb.velocity.y < 0)
            {
                executeJumpCoyote();
            }
    }

    private void executeJump()
    {
        rb.AddForce(Vector2.up * jumpForce * 100f);
        jumpTime = 0;
    }
    private void executeJumpCoyote()
    {
        rb.AddForce(Vector2.up * jumpForce * 4f, ForceMode2D.Impulse);
        jumpTime = 0;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
}
