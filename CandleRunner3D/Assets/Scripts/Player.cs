using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;

    public Joystick joystick;

    public float forwardSpeed = 1.0f;

    public float leftRightSpeed = 1.0f;

    public Vector2 minMaxX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
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
}
