using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    // Gjort av Aiden
    [Header("Playermovement")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private bool isFacingRight = true;
    private bool isGrounded = false;
    private Rigidbody2D rb;

    public Animator animator; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Stop all input if paused or in dialogue
        if (PauseMenu.isPaused || PauseMenu.isInDialogue)
        {
            rb.linearVelocity = Vector2.zero; // ensures no movement
            return;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float moveDirection = Input.GetAxis("Horizontal");
        
        Move(moveDirection);

        if (moveDirection > 0 && !isFacingRight)
            Flip();
        else if (moveDirection < 0 && isFacingRight)
            Flip();

        if (Input.GetButtonDown("Jump") && isGrounded)
            Jump();

        //animation
        animator.SetBool("IsGrounded", isGrounded);

        animator.SetBool("IsFalling", rb.linearVelocityY < 0);

        animator.SetBool("IsMoving", Input.GetAxis("Horizontal") != 0);
    }

    private void Move(float direction)
    {
        print("Dir: " +direction);
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    // Called by NPC when dialogue starts
    public void StopMovement()
    {
        rb.linearVelocity = Vector2.zero;
    }
}

