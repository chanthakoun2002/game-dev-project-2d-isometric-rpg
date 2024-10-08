using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayeCombat : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement playerMovement;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;

    //public float attackCooldown = 1f; 

    //private bool isAttacking = false; // Flag to track whether the player is attacking

    public float attackRate = 2f; //allowed attacks per sec
    float nextAttackTime = 0f;

    void Update()
    {
        if(Time.time >= nextAttackTime){
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)){ 
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    
    void Attack()
    {
    
        animator.SetTrigger("Attack");

        // Detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("we hit" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage); 
        }
    }

    void OnDrawGizmosSelected() //allow for attack radius to be seen in unity
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    // IEnumerator AttackCoroutine()
    // {
    //     
    //     isAttacking = true;

    //     // Stop movement while attacking
    //     //playerMovement.StopMovement();

    //     
    //     animator.SetTrigger("Attack");

    //     // Detect enemies in range
    //     Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

    //     
    //     foreach (Collider2D enemy in hitEnemies)
    //     {
    //         Debug.Log("we hit" + enemy.name);
    //         enemy.GetComponent<Enemy>().TakeDamage(attackDamage); 
    //     }

    //     // Wait for attack cooldown
    //     yield return new WaitForSeconds(attackCooldown);

    //     
    //     isAttacking = false;

    //     // Resume movement
    //     //playerMovement.ResumeMovement();
    // }
}