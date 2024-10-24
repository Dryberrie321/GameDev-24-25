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
    /// <summary>
    /// Below has already been done during club times
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void sidewaysMovement()
    {
        horizontal = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    void Update()
    {
        sidewaysMovement();
        jump();
        groundCheck();
        
    }
    // up to here

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
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
}
