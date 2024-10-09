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
    private float jumpTimeCounter = 0.5f;
    [SerializeField] private float jumpTime;
    

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
    }

    private void executeJump()
    {
        rb.AddForce(Vector2.up.normalized * jumpForce * 100f);
        jumpTime = 0;
    }
}
