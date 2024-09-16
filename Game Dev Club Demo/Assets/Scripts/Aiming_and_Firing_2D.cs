using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script can also be used to create an object that rotates around a point to face the mouse's position
//Place this script on a point which will act as the orgin of rotation
    //Place a sprite nested underneath the rotation point if desired.

public class Aiming_and_Firing_2D : MonoBehaviour
{
    private Camera _cam;
    private Vector3 mousePos;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private float timeBetweenFiring = 3f;
    private bool canFire = false;
    private float timer;


    void Awake()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        rotation(); // Refrencing these functions here makes the code cleaning, and executes them at each update still.
        shoot();
        if (!canFire) // only use this is making a turret that fires a projectile
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
    }
    void rotation()
    {
        mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
    void shoot() //only use this is making a turret that fires a projectile
    {
        if (Input.GetMouseButton(0) && canFire == true)
        {
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
                //remember to set an object as the "bullet" in the inspector window

            canFire = false;
        }
    }
}
