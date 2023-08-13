using UnityEngine;

public class ActionMovement : MonoBehaviour
{
    private Animator animator;

    [Header("Player Settings")]
    public float speed = 8.0f;

    public float jumpHeight = 15.0f;

    public bool rotatable;

    public Vector3 move;

    private Vector2 mousePos;

    [Header("Ground Control")]
    public Transform groundCheck;

    public float groundDistance = 0.4f;

    public LayerMask groundMask;

    public bool isGrounded;

    private void Awake()
    {
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


        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        move = Vector2.right * x;

        bool IsRunning = move.x > Mathf.Epsilon ? true : false || move.x < -Mathf.Epsilon ? true : false;

        animator.SetBool("isRuning", IsRunning);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            move = Vector3.up * y;
            animator.SetBool("isJumping", isGrounded);
        }

        transform.position += move * speed * Time.deltaTime;
    }

      private void FlipSprite()
    {
        rotatable = Mathf.Abs(move.x) > Mathf.Epsilon;

        if (rotatable)
        {
            transform.localScale = new Vector3(Mathf.Sign(move.x), 1f);
        }
    }

    private void IsJumpable(bool condition)
    {
        isGrounded = condition;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumpable(true);
        }
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumpable(false);
        }
    }
}
