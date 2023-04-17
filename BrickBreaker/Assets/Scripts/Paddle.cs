using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D rb { get; private set; }

    public Vector2 direction { get; private set; }

    public float speed = 30.0f;

    public float maxBounceAnlge = 75f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.direction = Vector2.right;
        }
        else
        {
            this.direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (this.direction != Vector2.zero)
        {
            rb.AddForce(direction * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Vector3 paddlePosition = this.transform.position;
            Vector2 contactPoint = other.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float width = other.otherCollider.bounds.size.x / 2;

            float currentAngle =
                Vector2.SignedAngle(Vector2.up, ball.rb.velocity);

            float bounceAngle = (offset / width) * maxBounceAnlge;
            float newAngle = Mathf.Clamp(currentAngle+bounceAngle,-maxBounceAnlge,maxBounceAnlge);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rb.velocity = rotation * Vector2.up * ball.rb.velocity.magnitude;
        }
    }
}
