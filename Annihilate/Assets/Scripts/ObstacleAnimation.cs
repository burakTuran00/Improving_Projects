using System.Collections;
using UnityEngine;

public class ObstacleAnimation : MonoBehaviour
{
    public float rotateSpeed = 1.0f;

    [Range(0, 2)]
    public int rotateValue;

    private Vector3 rotateDirection;

    private void Update()
    {
        RotationObstacle();
    }

    private void RotationObstacle()
    {
        if (rotateValue == 0)
        {
            rotateDirection = Vector3.up;
        }
        else if (rotateValue == 1)
        {
            rotateDirection = Vector3.right;
        }
        else if (rotateValue == 2)
        {
            rotateDirection = Vector3.back;
        }

        transform.Rotate(rotateDirection * rotateSpeed);
    }
}
