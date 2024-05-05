using UnityEngine;
using UnityEngine.AI;

public class AiChase : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 10f; // Adjustable chase range
    NavMeshAgent agent;
    Enemy enemy; // Reference to the Enemy script
    public Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        // Get reference to the Enemy script attached to the same GameObject
        enemy = GetComponent<Enemy>();

        
        enemy.OnDeath.AddListener(OnEnemyDeath);
        
    }

    private void Update()
    {
        // Check if the enemy is alive before updating its movement
        if (!enemy.isDead)
        {
            // Check if the target is within the chase range
            if (target != null && Vector3.Distance(transform.position, target.position) <= chaseRange)
            {
                agent.SetDestination(target.position);
                // Calculate the speed of the NavMeshAgent
                float speed = agent.velocity.magnitude;
                // Update the animator parameter based on the speed
                animator.SetFloat("Speed", speed);
            }
            else
            {
                // Stop moving if the target is out of range
                agent.SetDestination(transform.position);
                //stop walk animation

                animator.SetFloat("Speed", 0f);
            }
        }
        else
        {
            // Stop moving if the enemy is dead
            agent.SetDestination(transform.position);
            animator.SetFloat("Speed", 0f);
        }
    }
    void OnDrawGizmosSelected()
    {
        // Draw a wire sphere to visualize the chase range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
    // Method to handle enemy's death
    private void OnEnemyDeath()
    {
        // Stop moving when the enemy dies
        agent.SetDestination(transform.position);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

}
