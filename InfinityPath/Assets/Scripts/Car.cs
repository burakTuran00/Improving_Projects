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
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.zero;
        }

        transform.position += direction * speed * Time.deltaTime;
    }
}
