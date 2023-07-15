using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool thrusting;

    public float thrustSpeed = 1.0f;

    private float turnDirection;

    public float turnSpeed = 1.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        if (thrusting)
        {
            rb.AddForce(transform.up * thrustSpeed);
        }

        if (turnDirection != 0)
        {
            rb.AddTorque(turnDirection * turnSpeed);
        }
    }

    private void Move()
    {
        thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turnDirection = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turnDirection = -1.0f;
        }
    }
}
