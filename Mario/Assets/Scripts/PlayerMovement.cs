using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private Camera cam;

    private Vector2 velocity;

    private float inputAxis;

    [Range(1, 14)]
    public float moveSpeed = 8.0f;

    public float maxJumpHeight = 5.0f;

    public float maxJumpTime = 1.0f;

    public float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f);

    public float gravity =>
        (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f), 2);

    public bool grounded { get; private set; }

    public bool jumping { get; private set; }

    public bool sliding =>
        (inputAxis > 0f && velocity.x < 0f) ||
        (inputAxis < 0f && velocity.x > 0f);

    public bool running =>
        Mathf.Abs(velocity.x) > Mathf.Epsilon ||
        Mathf.Abs(inputAxis) > Mathf.Epsilon;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    private void Update()
    {
        HorizontalMovement();

        grounded = rb.Raycast(Vector2.down);

        if (grounded)
        {
            GroundedMovement();
        }

        ApplyGravity();
    }

    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        position += velocity * Time.fixedDeltaTime;

        Vector2 leftEdge = cam.ScreenToWorldPoint(Vector3.zero);
        Vector2 rightEdge =
            cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        position.x =
            Mathf.Clamp(position.x, leftEdge.x + 0.5f, rightEdge.x - 0.5f);

        rb.MovePosition (position);
    }

    private void HorizontalMovement()
    {
        inputAxis = Input.GetAxis("Horizontal");
        velocity.x =
            Mathf
                .MoveTowards(velocity.x,
                inputAxis * moveSpeed,
                Time.deltaTime * moveSpeed);

        if (rb.Raycast(Vector2.right * velocity.x))
        {
            velocity.x = 0;
        }

        if (velocity.x > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (velocity.x < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }

    private void GroundedMovement()
    {
        velocity.y = Mathf.Max(velocity.y, 0f);
        jumping = velocity.y > 0;

        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = jumpForce;
            jumping = true;
        }
    }

    private void ApplyGravity()
    {
        bool falling = velocity.y < 0 || !Input.GetButtonDown("Jump");
        float multiplier = falling ? 2.0f : 1.0f;

        velocity.y += gravity * multiplier * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (transform.DotTest(other.transform, Vector2.down))
            {
                velocity.y = jumpForce / 2f;
                jumping = true;
            }
        }
        else if (other.gameObject.layer != LayerMask.NameToLayer("PowerUp"))
        {
            if (transform.DotTest(other.transform, Vector2.up))
            {
                velocity.y = 0;
            }
        }
    }
}
