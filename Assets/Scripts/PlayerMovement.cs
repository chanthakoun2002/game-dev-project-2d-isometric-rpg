using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    public Animator animator;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //keyboard inputs
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
        
        //trigger run animation when player moves
        animator.SetFloat("speed", Mathf.Abs(horizontalInput + verticalInput));



    }
}
