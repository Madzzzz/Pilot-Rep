﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float health;                         // How much health the player has left.
    
    private PlayerController playerController;          // Reference to the player movement script.
    private bool playerDead = false;                    // A bool to show if the player is dead or not.

    public Text HealthDisplay;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }


    void Update()
    {
        // If health is less than or equal to 0...
        if (health <= 0f)
        {
            health = 0f;
            // ... and if the player is not yet dead...
            if (!playerDead)
                // ... call the PlayerDying function.
                PlayerDying();
            else
            {
                DeathScreen();
            }
        }

        //HealthDisplay.text = "Health: " + health;
    }


    void PlayerDying()
    {
        // The player is now dead.
        playerDead = true;
    }

    void DeathScreen()
    {
        playerController.enabled = false;
        Camera.main.GetComponent<MouseScript>().DeathScreen();
        GameObject.Find("DeathScreen").GetComponent<DeathMenu>().ShowDeathmenu();
        health = 1;
    }


    public void TakeDamage(float amount)
    {
        // Decrement the player's health by amount.
        health -= amount;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == ("Enemy"))
        {
            TakeDamage(1);
        }
    }
}