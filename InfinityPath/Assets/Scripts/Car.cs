using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 5.0f;

    private Vector3 direction;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        direction.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        direction.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.position += direction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    }
}
