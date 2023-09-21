using UnityEngine;

public class Movement : MonoBehaviour
{
    public Joystick joystick;

    public Vector3 direction;

    public float forwardSpeed = 1.0f;

    public float leftRightSpeed = 1.0f;

    public Vector2 minMaxX;

    public bool atFinal {get;  set;}

    private void Awake() {
        atFinal = false;
    }
    private void OnEnable() {
        atFinal = false;
    }

    private void Update()
    {
        playerMove();
    }

    private void playerMove()
    {
        if (!atFinal)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minMaxX.x, minMaxX.y), transform.position.y,transform.position.z);

            float xMovement = joystick.Horizontal * leftRightSpeed * Time.deltaTime;
            transform.position += new Vector3(xMovement, 0f, forwardSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);

            float xMovement = -joystick.Horizontal * leftRightSpeed * Time.deltaTime;
            float zMovement = -joystick.Vertical * forwardSpeed * Time.deltaTime;

            transform.position += new Vector3(xMovement, 0f, zMovement);
        }
    }
}
