using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{

    public int maxHealth = 5;               // Max health represented by hearts (e.g., 5 hearts = 100% health)
    private int currentHealth;              // Current health represented by hearts
    public Image[] heartImages;             // Array to hold heart images
    public Sprite fullHeart;                // Sprite for a full heart
    public Sprite emptyHeart;               // Sprite for an empty heart
    public Animator Ani;                    // Reference to the Animator
    public GameObject Reset_Button;
   /* public float damagePerSecond = 10f;   // Damage dealt to player per second
    public float damageInterval = 1f;     // How often the player takes damage
    private float damageTimer = 0f;       // Timer to track damage intervals
    public int enemyDamageAmount = 1;  // Damage the player deals to the enemy
*/
     
    // Start is called before the first frame update
    void Start()
    {
       
        currentHealth = maxHealth;
        UpdateHeartsUI();
    }

    // Method to take damage
    public void TakeDamage_Player(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Damage player"+ damage);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        UpdateHeartsUI();
    }

    // Method to heal the player
    public void Heal(int healingAmount)
    {
        currentHealth += healingAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateHeartsUI();
    }

    // Method to handle player death
    void Die()
    {  
        if(Ani != null)
        {
         Debug.Log("Player has died!");
         Ani.SetTrigger("Death");
        // Add additional death logic here (e.g., disable player control, show reset button)
         Destroy(this.gameObject, 2f);
         Reset_Button.SetActive(true);
        }
        else
        {
            Debug.LogError("Animator not assigned!");
        }
        
    }

    // Update the hearts UI
    void UpdateHeartsUI()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < currentHealth)
            {
                heartImages[i].sprite = fullHeart;    // Set full heart sprite
            }
            else
            {
                heartImages[i].sprite = emptyHeart;   // Set empty heart sprite
            }

            // Ensure heart image is active only if it should be displayed (optional)
            heartImages[i].enabled = i < maxHealth;
        }
    }
  
    
   /* // Called when the player stays inside a trigger collider (2D)
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object the player is in contact with has the "Enemy" tag
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Damage the player over time
            damageTimer += Time.deltaTime; // Increment timer by time elapsed since last frame

            if (damageTimer >= damageInterval)
            {
                TakeDamage((int)damagePerSecond);  // Player takes damage
                damageTimer = 0f;             // Reset timer after damage is dealt
            }

            // Attempt to damage the enemy as well
            Debug.Log("Enemy detected");
            
            // Ensure that the enemy has an Enemy_Health script
            Enemy_Health enemyHealth = other.GetComponent<Enemy_Health>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(enemyDamageAmount);  // Deal damage to the enemy
            }
            else
            {
                Debug.LogError("Enemy does not have an Enemy_Health component!");
            }
        }
    }*/
    // Trigger event for damage (example usage for traps or enemies)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
           Ani.SetTrigger("Death");
           Destroy(gameObject,0.4f); // Example: take 1 heart of damage
           Reset_Button.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Heart"))
        {
          
            Heal(1);  // Example: heal 1 heart
            Destroy(other.gameObject);
        }
    }
    /* public void Reset()
    {
        Debug.Log("Reset button pressed.");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }*/
}
 
   