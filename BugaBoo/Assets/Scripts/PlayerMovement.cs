using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private SpriteRenderer sprite;

    private Animator animator;

    public float speed = 5f;

    [Range(1, 10)]
    public float jumpForce = 8f;

    private float horMov;

    private bool isGrounded = false;

    private enum MovementState
    {
        idle,
        running,
        jumping,
        falling
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horMov = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horMov * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (horMov > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (horMov < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int) state);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground") || other.transform.CompareTag("Trap"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground") || other.transform.CompareTag("Trap"))
        {
            isGrounded = false;
        }
    }
}
