using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour //this script handles player health 
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public Animator animator;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); 
    }

    

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Q)){ //this if for testing Purposes
        //     TakeDamage(20);
        // }
        
    }

    public void TakeDamage(int damage)
    {
        
        animator.SetTrigger("Hurt");
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Died");
        // note: add aniamtion and other logic later
    }
}
