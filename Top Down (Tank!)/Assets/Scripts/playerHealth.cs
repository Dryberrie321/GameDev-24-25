using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // really need this part, it does not come standard on all created scripts, and tells the negine to use the UI system

//This script goes on the player, and records the amount of health at the beginning, along with making changes to the health bar if it takes damage.

public class playerHealth : MonoBehaviour
{
    public float health; // The player's current health
    public float maxHealth; // the health that the player starts out with
    public Image healthBar; // finding the UI element that comprises the sliding health bar --- Readme @ bottom...

    // unlike the other scripts, the floats must be "public" because other scripts must access it other than this one.

    void Start()
    {
        maxHealth = health; // At the start of the game, set the maximum health to whatever you set the health to in the inspector
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1); 
            // On the UI element of the image, set the image sliding bar to a value between 0 to 1
            //This code sets the the ratio of current health to maximum health on a scale of 0 - 1
        if (health <= 0)
        {
            Destroy (this.gameObject);
        }
        // if the health is less or equal zero, destroy the player.
    }
}


//Readme ----- How to enable the Health Bar in Unity
/*
    In the Hierarchy, right click and create -- UI/canvas
        - The canvas places the images on the screen
        - To make sure the canvas is lined up on the screen...
            - Render mode to "ScreenSpace - Overview"
            - UI scale mode to "Scale With Screen Space"
   
    As a child of the canvas, right click again and create -- UI/image
        - Select the sprite as a square and set it to "fillable"

*/
