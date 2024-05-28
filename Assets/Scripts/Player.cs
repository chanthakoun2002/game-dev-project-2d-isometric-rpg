using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public Animator animator;
    

    void Start()
    {
        // Set the current health to the default health value
        currentHealth = maxHealth;
        
        // Load player health from PlayerPrefs
        int savedHealth = PlayerData.LoadPlayerHealth();
        if (savedHealth > 0)
        {
            currentHealth = savedHealth;
        }

        // Set up the health bar
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    public void RestoreHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
        PlayerData.SavePlayerHealth(currentHealth);
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
        // Save player health after taking damage
        PlayerData.SavePlayerHealth(currentHealth);
    }

    void Die()
    {
        Debug.Log("Player Died");
        //note: add other death features here

        PlayerData.SavePlayerHealth(maxHealth); // Reset health to default
        
        //NOTE: future me maybe add a panel for usewr when dead to either load a save or exit main menu

        //when player dies it will bring user to main menu
        GameManager.instance.ClearGameData();
        SceneManager.LoadScene(0);

    }
}