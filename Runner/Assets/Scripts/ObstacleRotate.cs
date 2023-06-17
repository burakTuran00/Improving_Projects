using UnityEngine;

public class ObstacleRotate : MonoBehaviour
{
    public float rotateSpeed = 1.0f;

    [Range(0, 2)]
    public int rotateKind;

    private Vector3 rotateDirection;

    private void Update()
    {
        RotationObstacle();
    }

    private void RotationObstacle()
    {
        if (rotateKind == 0)
        {
            rotateDirection = Vector3.up;
        }
        else if (rotateKind == 1)
        {
            rotateDirection = Vector3.right;
        }
        else
        {
            rotateDirection = Vector3.back;
            transform.position += rotateDirection * Time.deltaTime;
        }

        transform.Rotate(rotateDirection * rotateSpeed);
    }
}
