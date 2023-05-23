using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 5.0f;

    private Vector3 directionHor;

    private void Update()
    {
        HorizontalMove();
    }

    private void HorizontalMove()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            directionHor = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            directionHor = Vector3.right;
        }
        else
        {
            directionHor = Vector3.zero;
        }

        transform.position += directionHor * speed * Time.deltaTime;
    }

    private void VerticalMove()
    {
        
    }
}
