using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]
    private CharacterController controller;

    public float speed = 8.0f;

    public float jumpHeight = 5.0f;

    [Header("Ground Control")]
    public Transform groundCheck;

    public float groundDistance = 0.4f;

    public LayerMask groundMask;

    public bool isGrounded;

    [Header("Gravity Settings")]
    public float gravity = -9.81f;

    private Vector3 velocity;


    private void Awake() 
    {
        controller = GetComponent<CharacterController>();    
    }

    private void Update() 
    {
        Move();
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 move = Vector2.right * x + Vector2.up * y;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
