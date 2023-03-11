using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator animator;

    [Range(1, 20)]
    public float jumpForce = 12f;

    private bool isGrounded = false;

    enum MovementState
    {
        running,
        jumping,
        falling
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        AnimaitonState();
    }

    private void AnimaitonState()
    {
        MovementState state;

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        else
        {
            state = MovementState.running;
        }

        animator.SetInteger("state", (int) state);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
