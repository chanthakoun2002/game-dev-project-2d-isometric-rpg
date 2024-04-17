using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    public Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool canMove = true; // Flag to track whether the player can move

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)//  <-- this is not being used right now
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Calculate the movement direction based on input
            Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

            // Apply movement to the Rigidbody
            rb.velocity = movement * moveSpeed;

            // Flip character sprite when moving left
            if (horizontalInput < 0)
            {
                spriteRenderer.flipX = true;
            }
            // Flip character sprite back to normal when moving right
            else if (horizontalInput > 0)
            {
                spriteRenderer.flipX = false;
            }

            // Trigger run animation when player moves
            animator.SetFloat("speed", Mathf.Abs(horizontalInput + verticalInput));
        }
        else
        {
            // Stop movement if player cannot move
            rb.velocity = Vector2.zero;
        }
    }



    // below code is not used currently  
    public void StopMovement()
    {
        // Set canMove flag to false to prevent movement
        canMove = false;
    }

    public void ResumeMovement()
    {
        // Set canMove flag to true to allow movement
        canMove = true;
    }
}
