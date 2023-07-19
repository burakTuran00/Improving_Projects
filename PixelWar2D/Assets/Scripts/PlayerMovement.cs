using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]
    private CharacterController controller;

    private Animator animator;

    public float speed = 8.0f;

    public float jumpHeight = 5.0f;

    public bool rotatable;

    public Vector2 move;

    private Vector2 mousePos;

    [Header("Ground Control")]
    public Transform groundCheck;

    public float groundDistance = 0.4f;

    public LayerMask groundMask;

    public bool isGrounded;

    [Header("Gravity Settings")]
    public float gravity = -9.81f;

    public Vector3 velocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        FlipSprite();
    }

    private void Move()
    {
        isGrounded = Physics2D.OverlapArea(groundCheck.position, groundCheck.position);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        move = Vector2.right * x;

        bool IsRunning = move.x > Mathf.Epsilon ? true : false || move.x < -Mathf.Epsilon ? true : false;

        animator.SetBool("isRuning", IsRunning);
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            move = Vector2.up * y;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        bool IsJumping = velocity.y > 0.25f ? true : false;
        animator.SetBool("isJumping", IsJumping);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    

    private void FlipSprite()
    {
        rotatable = Mathf.Abs(move.x) > Mathf.Epsilon;

        if (rotatable)
        {
            transform.localScale = new Vector3(Mathf.Sign(move.x), 1f);
        }
    }
}
