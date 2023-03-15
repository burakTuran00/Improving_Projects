using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;

    bool playerHasHorSpeed;

    private Rigidbody2D rb;

    private Animator animator;

    [SerializeField]
    float speed = 6f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Run();
        FlipSprite();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        // Debug.Log (moveInput);
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
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }
}
