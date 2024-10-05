using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedPlayerMovement : MonoBehaviour
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
    [SerializeField] private float jumpTimeCounter = 3f;
    [SerializeField] private float jumpTime;

    [SerializeField] private float gravOnUp = 1;
    [SerializeField] private float gravOnDown = 1;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log(groundCheck());
        sidewaysMovement();
        jump();
        groundCheck();
        gravityChange();

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

        if (Input.GetKeyDown("space")) /*&& (groundCheck() == false)) */
        {
            jumpTime = jumpTimeCounter;
        }
        else
        {
            jumpTime -= Time.deltaTime;
        }

        if ((coyoteTime >= 0.0f) && (coyoteTime != coyoteTimeCounter) && (Input.GetKeyDown("space")) && (rb.velocity.y < 0f))
        {
            rb.velocity = new Vector2(0, 0);
            executeJumpCoyote();
        }

        if ((jumpTime >= 0.0f) && (groundCheck() == true) && (rb.velocity.y <= 0))
        {
            executeJumpCoyote();
        }

    }
    private void executeJumpCoyote()
    {
        rb.AddForceAtPosition(Vector2.up.normalized * jumpForce * 150, this.transform.position);
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
    private void gravityChange()
    {
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = gravOnDown;
        }
        else
        {
            rb.gravityScale = gravOnUp;
        }
    }
}
