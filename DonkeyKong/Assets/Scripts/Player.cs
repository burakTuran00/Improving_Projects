using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    private new Collider2D collider;

    private Collider2D[] results = new Collider2D[4];

    private Vector2 direction;

    public float moveSpeed = 1.0f;

    public float jumpStrength = 1.0f;

    private bool grounded;

    private bool climbing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    private void CheckCollision()
    {
        grounded = false;
        climbing = false;

        Vector2 size = collider.bounds.size;
        size.y += 0.1f;
        size.x /= 2.0f;

        int amount =
            Physics2D.OverlapBoxNonAlloc(transform.position, size, 0, results);

        for (int i = 0; i < amount; i++)
        {
            GameObject hit = results[i].gameObject;

            if (hit.layer == LayerMask.NameToLayer("Ground"))
            {
                grounded =
                    hit.transform.position.y < (transform.position.y - 0.5f);

                Physics2D.IgnoreCollision(collider, results[i], !grounded);
            }
            else if (hit.layer == LayerMask.NameToLayer("Ladder"))
            {
                climbing = true;
            }
        }
    }

    private void Update()
    {
        CheckCollision();

        Jumping();
        PlayerMovement();
        PlayerFlip();
    }

    private void PlayerMovement()
    {
        direction.x = Input.GetAxis("Horizontal") * moveSpeed;

        if (grounded)
        {
            direction.y = Mathf.Max(direction.y, -1.0f);
        }

        rb.MovePosition(rb.position + direction * Time.fixedDeltaTime);
    }

    private void PlayerFlip()
    {
        if (direction.x > 0f)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (direction.x < 0f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }

    private void Jumping()
    {
        if (climbing)
        {
            direction.y = Input.GetAxis("Vertical") * moveSpeed;
        }
        else if (Input.GetButtonDown("Jump") && grounded)
        {
            direction = Vector2.up * jumpStrength;
        }
        else
        {
            direction += Physics2D.gravity * Time.deltaTime;
        }
    }
}
