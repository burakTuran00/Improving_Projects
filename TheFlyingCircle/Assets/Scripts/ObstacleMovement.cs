using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float xPosition;

    private bool rightMovable = true;

    public float speed = 3f;

    private void Update()
    {
        Rotate();
        TurnDirection();
        Move();
    }

    public void Move()
    {
        if (rightMovable)
        {
            //movement right
           Vector3 newRightPosition = new Vector3(xPosition, 0f,transform.position.z);
           transform.position = Vector3.Lerp(transform.position,newRightPosition,Time.deltaTime * speed);
        }
        else
        {
            //movement left
            Vector3 newLeftPosition = new Vector3(-xPosition,0f,transform.position.z);
            transform.position = Vector3.Lerp(transform.position,newLeftPosition,Time.deltaTime * speed);
        }
    }

    public void TurnDirection()
    {
        if(transform.position.x >= 3.950f)
        {
            rightMovable = false;
        }
        else if(transform.position.x <= -3.950f)
        {
            rightMovable = true;
        }
    }

    public void Rotate()
    {
        transform.Rotate(new Vector3(0f, 0f, 1f));
    }
}
