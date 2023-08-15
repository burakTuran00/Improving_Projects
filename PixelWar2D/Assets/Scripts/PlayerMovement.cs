using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator animator;

    private ShootingSystem shootingSystem;

    private Vector3 move;

    [Range(1, 25)]
    public float speed = 8.0f;

    [Range(1, 25)]
    public float jumpForce = 12.0f;

    public Transform shootingPosition;

    private bool rotatable;

    public bool IsJumping;

    public bool movable;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        shootingSystem = GetComponent<ShootingSystem>();
    }

    private void Update()
    {
        Move();
        Jump();
        Lean();
        FlipSprite();
    }

    private void Move()
    {
        if (movable)
        {
            move.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

            bool IsRunning = move.x > Mathf.Epsilon ? true : false || move.x < -Mathf.Epsilon ? true : false;
            animator.SetBool("isRunning", IsRunning);
            transform.position += move;
        }
        
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsJumping)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void Lean()
    {
        if (Input.GetKey(KeyCode.LeftControl) && IsJumping)
        {
            shootingPosition.localPosition = new Vector3(0.5f , -0.3f , 0f);
            animator.SetBool("isLeaning", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) && IsJumping)
        {
             shootingPosition.localPosition = new Vector3(0.5f , 0.1f , 0f);
            animator.SetBool("isLeaning", false);
            
        }
    }

    private void FlipSprite()
    {
        rotatable = Mathf.Abs(move.x) > Mathf.Epsilon;

        if (rotatable)
        {
            transform.localScale = new Vector3(Mathf.Sign(move.x), 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = true;
            animator.SetBool("isJumping", false);
        }    
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
         if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
            animator.SetBool("isJumping", true);
        }
    }
}
