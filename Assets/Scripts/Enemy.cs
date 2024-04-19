using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    public Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage){
        //note: damage on enemy is based on attackDamage set in playerCombat script
        currentHealth -= damage;

        //play hurt animation
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0){
            //if 0 health enemy should die
            Die();
        }
    }

    void Die(){
        Debug.Log("Enemy Died");
        //die animation
        animator.SetTrigger("Death");

        //disable the enemy
        //turn off collision of enemy when dead
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

    }


}
