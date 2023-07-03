using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;

    private Vector3 direction;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        direction.x = Input.GetAxis("Horizontal");

        transform.position += direction * speed * Time.deltaTime;
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }
}
