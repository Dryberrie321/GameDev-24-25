using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    private Vector3 mousePos;
    private Camera _cam;
    [SerializeField] private float force = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   //Get the RigidBody component

        _cam = Camera.main; //Find the main camera in the scene and store it in the script as a variable.

        mousePos = _cam.ScreenToWorldPoint(Input.mousePosition); // The location of the mouse is based on where it appears on the screen. Screen to world point turns it into a number we can use to position game objects.

        Vector3 direction = mousePos - transform.position; //mouse position - orgin of instantiation = direction to travel

        Vector3 rotation = transform.position - mousePos; // orgin of instantiation - mouse position = rotation of object

        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        //Set the velocity of the object to the direction already calculated
        //normalize means to take the values and clamp it to 1 or -1, ensuring that the distance of the mouse does not account towards speed
        //Multiplying the force afterwards ensures a consistent speed each time.

        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

    
        Destroy(this.gameObject, 3f);// 3 seconds after spawning this object, delete it.
        
    }
        /*
    void OnCollisionEnter2D (Collision2D collision)
    {
        Destroy(this.gameObject);

        Debug.Log("Collision");
    }

    */
    }
