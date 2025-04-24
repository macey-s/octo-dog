using UnityEngine;
using UnityEngine.UI;  // Make sure you have the UI namespace for sliders

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;  // Maximum health
    public int currentHealth;    // Current health
    public Slider healthSlider;  // Reference to the health slider in the UI

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // You can trigger a death event here if you need to
        }
    }

    // Method to heal the player
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth) // Prevent exceeding max health
        {
            currentHealth = maxHealth;
        }

        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;  // Update health slider
        }
    }

    // Method to reset health
    public void ResetHealth()
    {
        currentHealth = maxHealth;  // Reset health to the max value
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;  // Update health slider
        }
    }
}