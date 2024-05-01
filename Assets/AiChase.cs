using UnityEngine;
using UnityEngine.AI;

public class AiChase : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 10f; // Adjustable chase range
    NavMeshAgent agent;
    Enemy enemy; // Reference to the Enemy script

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
            }
            else
            {
                // Stop moving if the target is out of range
                agent.SetDestination(transform.position);
            }
        }
        else
        {
            // Stop moving if the enemy is dead
            agent.SetDestination(transform.position);
        }
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
