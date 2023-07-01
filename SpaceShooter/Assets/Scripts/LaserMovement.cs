using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    public float laserSpeed = 1.0f;

    public Vector3 direction;

    public float laserDelay = 1.0f;

    private void OnEnable()
    {
        Destroy(this.gameObject, laserDelay);
    }

    private void Update()
    {
        transform.position += direction * laserSpeed * Time.deltaTime;
    }
}
