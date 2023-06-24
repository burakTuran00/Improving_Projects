using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 direction = Vector3.zero;

    private void Update()
    {
        MoveF();
    }

    private void MoveF()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector3.back;
        }
        else
        {
            direction = Vector3.zero;
        }

        transform.position += direction;
    }
}
