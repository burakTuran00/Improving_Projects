using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 velocity;

    private float inputAxis;

    [Range(1, 14)]
    public float moveSpeed = 8.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HorizontalMovement();
    }

    private void FixedUpdate() 
    {
        Vector2 position = rb.position;
        position += velocity * Time.fixedDeltaTime;

        rb.MovePosition(position);    
    }

    private void HorizontalMovement()
    {
        inputAxis = Input.GetAxis("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, Time.deltaTime * moveSpeed);
    }
}
