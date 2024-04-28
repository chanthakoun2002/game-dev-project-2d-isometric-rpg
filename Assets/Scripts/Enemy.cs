using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Animator animator;
    public int damage = 5; //damage enemy can do
    public float attackCooldown = 2f; // Adjust as needed
    private bool canAttack = true;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        // if (canAttack)
        // {
        //     StartCoroutine(AttackCooldown());
        //     animator.SetTrigger("Attack");
        // }
    }

    private IEnumerator AttackCooldown()
    {
        //a cooldown before the enemy can attack the player again
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null  && canAttack)
            {

                animator.SetTrigger("Attack");
                player.TakeDamage(damage);
                StartCoroutine(AttackCooldown());
                
            }
        }
    }

    public void TakeDamage(int damage){ //this function if for the damage taken to enemy
        
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