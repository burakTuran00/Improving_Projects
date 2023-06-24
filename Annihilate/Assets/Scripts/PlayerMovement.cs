using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 1.0f;

    public float turnSpeed = 1.0f;

    private Vector3 forwardDirection = Vector3.forward;

    private Vector3 turnDirection;

    private void Update()
    {
        MoveForward();
        MoveTurn();
    }

    private void MoveForward()
    {
        transform.position += forwardDirection * forwardSpeed * Time.deltaTime;
    }

    private void MoveTurn()
    {
        turnDirection.x =
            Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

        transform.position += turnDirection;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("FinishLine"))
        {
            forwardDirection = Vector3.zero;
        }
    }
}
