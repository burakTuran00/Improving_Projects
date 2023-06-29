using UnityEngine;

public class AutoMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    public float sideSpeed = 1.0f;

    private void FixedUpdate()
    {
        Movemnet();
    }

    private void Movemnet()
    {
        float forwardDirection = Input.GetAxis("Vertical");
        forwardDirection = forwardDirection * Time.deltaTime * moveSpeed;

        float sideDirection = Input.GetAxis("Horizontal");
        sideDirection = sideDirection * sideSpeed;

        transform.Translate(Vector3.up * forwardDirection);
        transform.Rotate(0f, 0f, -sideDirection);
    }
}
