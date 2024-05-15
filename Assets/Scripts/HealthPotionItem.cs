using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthPotionItem : MonoBehaviour
{
    public HealthPotion healthPotion;

    // Method to use the health potion
    public void UseHealthPotion()
    {
        // Add health to the player
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.RestoreHealth(healthPotion.healthRestored);
        
        // Remove the potion from the inventory
        Destroy(gameObject);
    }
}
