using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 6.0f;

    [SerializeField]
    float jumpForce = 8.0f;

    [SerializeField]
    float climbSpeed = 8.0f;

    [SerializeField]
    Vector2 deathKick = new Vector2(20.0f, 20.0f);

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform gun;

    Vector2 moveInput;

    private bool playerHasHorSpeed;

    private bool playerHasVerSpeed;

    private Rigidbody2D rb;

    private Animator animator;

    private CapsuleCollider2D capsuleCollider2D; //Body

    private BoxCollider2D boxCollider2D; // Feet

    private float gravityScaleAtStart;

    private bool isAlive = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        gravityScaleAtStart = rb.gravityScale;
    }

    private void Update()
    {
        if (!isAlive)
        {
            return;
        }

        Run();
        FlipSprite();
        ClimbLatter();
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

    private void OnMove(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }

        moveInput = value.Get<Vector2>();
        // Debug.Log (moveInput);
    }

    private void OnJump(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }

        if (!boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        if (value.isPressed)
        {
            rb.velocity += new Vector2(0.0f, jumpForce);
        }
    }

    private void Run()
    {
        Vector2 playerVelocity =
            new Vector2(moveInput.x * speed, rb.velocity.y);
        rb.velocity = playerVelocity;

        animator.SetBool("isRunning", playerHasHorSpeed);
    }

    private void FlipSprite()
    {
        playerHasHorSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (playerHasHorSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1.0f);
        }
    }

    private void ClimbLatter()
    {
        if (!boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            rb.gravityScale = gravityScaleAtStart;
            animator.SetBool("isClimbing", false);
            return;
        }

        Vector2 climbVelocity =
            new Vector2(rb.velocity.x, moveInput.y * climbSpeed);

        rb.velocity = climbVelocity;
        rb.gravityScale = 0.0f;

        playerHasVerSpeed = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;

        animator.SetBool("isClimbing", playerHasVerSpeed);
    }

    private void Die()
    {
        if (
            capsuleCollider2D
                .IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazard"))
        )
        {
            isAlive = false;
            animator.SetTrigger("Dying");
            rb.velocity = deathKick;
        }
    }
}
