using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.0f;

    private Vector3 direction;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        transform.position += direction * speed * Time.deltaTime;
    }
}
