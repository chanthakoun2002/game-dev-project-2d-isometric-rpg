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

    //public float attackCooldown = 1f; // Adjust this value to set the delay before resuming movement after the attack

    //private bool isAttacking = false; // Flag to track whether the player is attacking

    public float attackRate = 2f; //allowed attacks per sec
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime){
            if(Input.GetKeyDown(KeyCode.Space)){
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        // if (!isAttacking && Input.GetKeyDown(KeyCode.Space))
        // {
        //     StartCoroutine(AttackCoroutine());
        // }
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     Attack();
        // }
    }

    // IEnumerator AttackCoroutine()
    // {
    //     // Set isAttacking flag to true
    //     isAttacking = true;

    //     // Stop movement while attacking
    //     //playerMovement.StopMovement();

    //     // Play attack animation
    //     animator.SetTrigger("Attack");

    //     // Detect enemies in range
    //     Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

    //     // Damage enemies
    //     foreach (Collider2D enemy in hitEnemies)
    //     {
    //         Debug.Log("we hit" + enemy.name);
    //         enemy.GetComponent<Enemy>().TakeDamage(attackDamage); 
    //     }

    //     // Wait for attack cooldown
    //     yield return new WaitForSeconds(attackCooldown);

    //     // Reset isAttacking flag to false
    //     isAttacking = false;

    //     // Resume movement
    //     //playerMovement.ResumeMovement();
    // }
    void Attack()
    {
        

        // Play attack animation
        animator.SetTrigger("Attack");

        // Detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage enemies
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
}