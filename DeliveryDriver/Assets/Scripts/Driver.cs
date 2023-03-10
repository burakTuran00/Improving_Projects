using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]
    float steerSpeed = 150.0f;

    [SerializeField]
    float moveSpeed = 5.0f;

    private void Update()
    {
        float steerAmount =
            Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount =
            Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0f, 0f, -steerAmount);
        transform.Translate(0f, moveAmount, 0f);
    }

    public void BoostSpeed(float BoostSpeed)
    {
        moveSpeed = BoostSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Obstacle"))
        {
            moveSpeed = 5.0f;
        }
    }
}
