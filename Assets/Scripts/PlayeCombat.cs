using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayeCombat : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){

            Attack();
        }
    }
    void Attack()
    {
        animator.SetTrigger("Attack");

<<<<<<< Updated upstream
    void Attack(){
        //play attack animation
        animator.SetTrigger("Attack");

    }
}
=======
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

    //May need commented code for later...  ignore for now
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
}
>>>>>>> Stashed changes
