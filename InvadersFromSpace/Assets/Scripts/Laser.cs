using UnityEngine;

public class Laser : MonoBehaviour
{
    public Vector3 direciton;

    public float speed = 1.0f;

    public float laserDestroyTime = 1.0f;

    private void OnEnable()
    {
        Destroy(gameObject, laserDestroyTime);
    }

    private void Update()
    {
        transform.position += direciton * speed * Time.deltaTime;
    }
}
