using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float health = 100f;                         // How much health the player has left.
    public float resetAfterDeathTime = 5f;              // How much time from the player dying to the level reseting.
    
    private PlayerController playerController;              // Reference to the player movement script.
    private float timer;                                // A timer for counting to the reset of the level once the player is dead.
    private bool playerDead = false;                    // A bool to show if the player is dead or not.

    public Text HealthDisplay;

    public Canvas deathScreen;

    void Start()
    {
        // Setting up the references.
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
                // Otherwise, if the player is dead, call the PlayerDead and LevelReset functions.
                PlayerDead();
                DeathScreen();
            }
        }

        HealthDisplay.text = "Health: " + health;
    }


    void PlayerDying()
    {
        // The player is now dead.
        playerDead = true;
        Debug.Log("Here thou incestuous, murderous, damned Dane/Drink off this potion: is thy union here?/Follow my mother");
    }


    public void PlayerDead()
    {
    }


    void DeathScreen()
    {
        playerController.enabled = false;
        Camera.main.GetComponent<MouseScript>().DeathScreen();
        deathScreen.enabled = true;
    }


    public void TakeDamage(float amount)
    {
        // Decrement the player's health by amount.
        health -= amount;
        Debug.Log("ouch i took " + amount + " damage, that really hurt");
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == ("Enemy"))
        {
            TakeDamage(1);
            gameObject.GetComponent<PlayerController>().tookDamage = true;
        }
    }
}