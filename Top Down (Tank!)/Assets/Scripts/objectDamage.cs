using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used for any objects that should do damage to the player - Bullets, enemies, etc.

public class objectDamage : MonoBehaviour
{
    public playerHealth pHealth; // New variable, this is refrencing the scipt that is attached to the player
    public float damage;

    void Start()
    {
        pHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
            // ^ This line is especially useful for applying scripts to Prefabs. Since prefabs can be loaded into any scene, you can't
            //drag a refrence to a script in the inspector. In this case, it is better to find the player object, and search for the script
            //that you need when the prefab is loaded into the scene.
    }
    void OnCollisionEnter2D(Collision2D other) //When a 2D collisison is detected with an object (other just meaning another object other than this one)
    {
        if (other.gameObject.CompareTag("Player")) //If the object has the same tag as the player...
        {
            pHealth.health -= damage; //Find the playerHealth script and the "health" variable and subtract the damage from it
            Destroy (this.gameObject); //Once hitting the player, delete this object. Can remove this if you don't want this...
        }
    }
}
