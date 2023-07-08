using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;

    public Joystick joystick;

    public float forwardSpeed = 1.0f;

    public float leftRightSpeed = 1.0f;

    public Vector2 minMaxX;

    public Vector3 decreaseScale;

    public float decreaseTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(Scaling), decreaseTime, decreaseTime);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position =
            new Vector3(Mathf.Clamp(transform.position.x, minMaxX.x, minMaxX.y),
                transform.position.y,
                transform.position.z);

        rb.velocity =
            new Vector3(joystick.Horizontal * leftRightSpeed * Time.deltaTime,
                rb.velocity.y,
                forwardSpeed * Time.deltaTime);
    }

    private void Scaling()
    {
        this.transform.localScale -= decreaseScale;

        if (transform.localScale.y < .25)
        {
            //todo
        }
    }
}
