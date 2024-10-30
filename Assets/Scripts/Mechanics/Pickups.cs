using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    // Triggered when another collider enters this trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            // Call a function to update score or inventory
            if (gameObject.tag == "Power-Up")
            {
                if (gameObject.name.Contains("FireFlower"))
                {
                    player.isBig = false;
                    player.isFire = true;
                }
                else if (gameObject.name.Contains("PowerShroom") && !player.isFire)
                {
                    player.isBig = true;
                }
            }
            if (gameObject.tag == "Coin")
            {

            }

            // Destroy the collectible
            Destroy(gameObject);
        }
    }
}
