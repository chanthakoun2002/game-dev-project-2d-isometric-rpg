using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Animator animator;
    public int damage = 5;
    public float attackCooldown = 2f;
    private bool canAttack = true;
    private bool allowAttackCooldown = true;
    public Transform attackPoint;
    public Transform searchRadius;
    public float attackRadius = 0.5f;
    public LayerMask playerLayer;
    public UnityEvent OnDeath;
    public bool isDead = false;
    public KillCount playerScore;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (canAttack == true  && allowAttackCooldown)
        {
            Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, playerLayer);

            foreach (Collider2D player in hitPlayers)
            {
                animator.SetTrigger("Attack");
                Debug.Log("enemy has attacked through hitRadius");
                player.GetComponent<Player>().TakeDamage(damage);
            }

            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        allowAttackCooldown = false;
        Debug.Log("enemy cooldown");
        yield return new WaitForSeconds(attackCooldown);
        allowAttackCooldown = true;
    }

    public void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy has taken damage");
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
            Die();
    }
    public void Die()
    {
        
        Debug.Log("Enemy Died");
        animator.SetTrigger("Death");
        playerScore.AddScore(1);//kill count for the player   //WIP

        if (OnDeath != null)
        {
            OnDeath.Invoke();
        }
        isDead = true;

        // //disable the enemy
        // //turn off collision of enemy when dead
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
            Debug.Log("collider should be turned off");  
            canAttack = false;
        }
        // Disable the entire GameObject
        gameObject.SetActive(false);//WIP
    }
}
