using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool canDoubleJump;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the player is grounded using a small circle at the player's feet.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);

        // Reset double jump ability when grounded.
        if (isGrounded)
        {
            canDoubleJump = true;
        }

        // Jump input.
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        // Move the player horizontally.
        float moveDirection = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            // Regular jump.
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else if (canDoubleJump)
        {
            // Double jump.
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            canDoubleJump = false;
        }
    }
}