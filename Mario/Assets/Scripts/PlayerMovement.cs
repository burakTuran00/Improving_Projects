using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private Camera cam;

    private Vector2 velocity;

    private float inputAxis;

    [Range(1, 14)]
    public float moveSpeed = 8.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    private void Update()
    {
        HorizontalMovement();
    }

    private void FixedUpdate() 
    {
        Vector2 position = rb.position;
        position += velocity * Time.fixedDeltaTime;

        Vector2 leftEdge = cam.ScreenToWorldPoint(Vector3.zero);
        Vector2 rightEdge = cam.ScreenToWorldPoint(new Vector2(Screen.width , Screen.height));

        position.x = Mathf.Clamp(position.x, leftEdge.x + 0.5f, rightEdge.x - 0.5f);

        rb.MovePosition(position);    
    }

    private void HorizontalMovement()
    {
        inputAxis = Input.GetAxis("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, Time.deltaTime * moveSpeed);
    }
}
