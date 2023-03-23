using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player")]
    public float speed = 8.0f;

    public float jumpForce = 12.0f;

    private Vector2 movement;

    private Rigidbody2D rb;

    private Animator animator;

    private bool playerHasHorSpeed;

    private enum MovementState
    {
        idle = 0,
        running = 1,
        jumping = 2,
        falling = 3
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Run();
        Flip();
        AnimatorState();
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.velocity += new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void Run()
    {
        Vector2 playerVelocity = new Vector2(movement.x * speed, rb.velocity.y);
        rb.velocity = playerVelocity;
    }

    private void Flip()
    {
        playerHasHorSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (playerHasHorSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1.0f);
        }
    }

    private Animator GetAnimator()
    {
        return animator;
    }

    private void AnimatorState()
    {
        MovementState state;

        if (movement.x > 0.0f || movement.x < 0.0f)
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int) state);
    }
}
