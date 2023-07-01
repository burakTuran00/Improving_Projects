using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    public float laserSpeed = 1.0f;

    private void Update()
    {
        transform.position += Vector3.up * laserSpeed * Time.deltaTime;
    }
}
