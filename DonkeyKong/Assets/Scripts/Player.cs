using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 direction;

    public float moveSpeed = 1.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerMovement();
        PlayerFlip();
    }

    private void PlayerMovement()
    {
        direction.x = Input.GetAxis("Horizontal") * moveSpeed;

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
}
