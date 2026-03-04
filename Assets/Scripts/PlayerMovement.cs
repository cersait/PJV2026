using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Playermovement")]
    public float moveSpeed = 5f; // 
    public float jumpForce = 5f; // 
    public float stamina = 100f;
    public Transform groundCheck; // 
    public float groundCheckRadius = 0.2f; // 
    public LayerMask groundLayer; // 
    private bool isFacingRight = true; 
    private bool isGrounded = false; 
    private Rigidbody2D rb;
    
    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody2D>(); // H�mta v�r Rigidbody 2D
    }
    private void Update()
    {

        if (PauseMenu.isPaused || PauseMenu.isInDialogue)
            return;


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); // Kolla om spelaren �r p� marken
        float moveDirection = Input.GetAxis("Horizontal");  // Kolla om vi r�r oss horisontellt
        Move(moveDirection); // Flytta spelaren
        if (moveDirection > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveDirection < 0 && isFacingRight) 
        {
            Flip();
        }
        if (Input.GetButtonDown("Jump") && isGrounded) // 
        {
            
            Jump();
        }
      
    }

    public void StopMovement()
    {
        rb.linearVelocity = Vector2.zero; // stop all current movement
    }

    private void Move(float direction)
    {
        Vector2 movement = new Vector2(direction * moveSpeed, rb.linearVelocity.y); // 
        rb.linearVelocity = movement;
    }
    private void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // 
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;  // Flippa player spriten horisontellt
        transform.Rotate(0f, 180f, 0f);
    }
    private void Run()
    {
        
    }
  
}

