using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Vector2 deathKick = new Vector2(20.0f, 20.0f);

    private Rigidbody2D rb;

    private Animator animator;

    private CapsuleCollider2D capsuleCollider2D; // Body Collider

    public GameObject bulletPrefab;

    public Transform gun;

    [Header("Player")]
    public float speed = 8.0f;

    public float jumpForce = 12.0f;

    private Vector2 movement;

    private bool playerHasHorSpeed;

    private bool isGround;

    private Vector2 mousePosition;

    public Camera cam;

    private bool isAlive = true;

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
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        if (!isAlive)
        {
            return;
        }

        Run();
        Flip();
        AnimatorState();
        Die();
    }

    private void OnFire(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }

        Instantiate(bulletPrefab, gun.position, transform.rotation);
    }

    void OnMove(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }

        movement = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }

        if (!capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

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

    private void Die()
    {
        if (
            capsuleCollider2D
                .IsTouchingLayers(LayerMask.GetMask("Enemy", "Spike"))
        )
        {
            isAlive = true;
            rb.velocity = deathKick;
        }
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
