using UnityEngine;

public class Movement : MonoBehaviour
{
    public Joystick joystick;

    public Vector3 direction;

    public float forwardSpeed = 1.0f;

    public float leftRightSpeed = 1.0f;

    public Vector2 minMaxX;

    private void Update()
    {
        playerMove();
    }

    private void playerMove()
    {
        transform.position =
            new Vector3(Mathf.Clamp(transform.position.x, minMaxX.x, minMaxX.y),
                transform.position.y,
                transform.position.z);

        float xMovement = joystick.Horizontal * leftRightSpeed * Time.deltaTime;
        transform.position +=
            new Vector3(xMovement, 0f, forwardSpeed * Time.deltaTime);
    }
}
