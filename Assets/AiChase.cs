using UnityEngine;
using UnityEngine.AI;
using System.Collections;



public class AiChase : MonoBehaviour
{
    [SerializeField] float chaseRange = 10f; // Adjustable chase range
    NavMeshAgent agent;
    Enemy enemy; // Reference to the Enemy script
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        // Get reference to the Enemy script attached to the same GameObject
        enemy = GetComponent<Enemy>();

        enemy.OnDeath.AddListener(OnEnemyDeath);

        // Find the player object dynamically using tag
        // GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        // if (playerObject != null)
        // {
        //     target = playerObject.transform;
        // }
        // else
        // {
        //     Debug.LogError("Player object not found. Make sure it is tagged as 'Player'.");
        // }
        // Start coroutine to find the player object after a short delay
        StartCoroutine(FindPlayer());
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
                // Flip the sprite renderer based on movement direction
                if (agent.velocity.x < 0)
                {
                    // Enemy is moving left
                    spriteRenderer.flipX = false;
                }
                else if (agent.velocity.x > 0)
                {
                    // Enemy is moving right
                    spriteRenderer.flipX = true;
                }
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
    IEnumerator FindPlayer()
    {
        //delay finding the player because the player loads in at a diffrent time
        //and enemy cant find them if this is put into the start at the start of the game....
        yield return new WaitForSeconds(0.5f);
        // Search for the player object by tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            // Set the player object as the target
            target = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Player object not found.");
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

    private Transform target; // Store the reference to the player object

    // Method to set the target (used if player object is not found in Start)
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

}