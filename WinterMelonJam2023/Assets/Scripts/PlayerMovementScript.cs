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
    private PlayerGameLogic playerGameLogic;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerGameLogic = GetComponent<PlayerGameLogic>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (playerGameLogic.HEALTH > 0)
        {
            // Check if the player is grounded using a small circle at the player's feet.
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.25f, groundLayer);

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
    }

    private void FixedUpdate()
    {
        if (playerGameLogic.HEALTH > 0)
        {
            // Move the player horizontally.
            float moveDirection = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

            // Set the "isRunning" parameter in the Animator based on the player's movement.
            bool isRunning = Mathf.Abs(moveDirection) > 0.1f;
            anim.SetBool("isRunning", isRunning);

            // Flip the x scale of the game object based on the movement direction.
            if (moveDirection > 0)
            {
                // Moving right.
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (moveDirection < 0)
            {
                // Moving left.
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
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