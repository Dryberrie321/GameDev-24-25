using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    private float horizontal;
    private float vertical;
    [SerializeField]
    private float speed = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //In the inspector of the player, find the rigidbody componenet and record it in a variable
    }

    void Update()
    {
         horizontalInput();
         verticalInput();
    }

    void horizontalInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        /*
        - record the horizontal input of the keyboard
        - GetAxisRaw is the inout of the keyboard, without any smoothing on the values. It returns either 1, 0 or -1
        - ("Horizontal") in this context is an inbuilt unity command to withdraw any horizontal inputs from the keybaord,
                either A&D or the arrow keys*/
    }
    void verticalInput()
    {
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate() 
        /*
          - Runs this function 50 times every section
          - Ensures that physics based calculations are done seperate from framerate*/
    {
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        /* get the velocity of the object, and set it to a new vector 2 (x input, y input)
        the x input is the horizontal input of the keyboard, multiplied by the speed of the character*/
    }
}
