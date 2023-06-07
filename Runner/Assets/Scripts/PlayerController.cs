using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed = 1.0f;

    public float horizontalSpeed = 1.0f;

    private void Update()
    {
        EndlessForwardMovement();
        HorizontalMovement();
    }

    private void EndlessForwardMovement()
    {
        transform.position += Vector3.forward * runningSpeed * Time.deltaTime;
    }

    private void HorizontalMovement()
    {
        float hor =
            Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;

        transform.position += Vector3.right * hor;
    }
}
