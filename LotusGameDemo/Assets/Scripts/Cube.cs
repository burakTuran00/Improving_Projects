using UnityEngine;

public class Cube : MonoBehaviour
{
    public int value;

    public bool isSum;

    private BulletSpawner bulletSpawner;

    private void Awake()
    {
        bulletSpawner = FindAnyObjectByType<BulletSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (
            other.gameObject.CompareTag("Player") ||
            other.gameObject.CompareTag("Cube")
        )
        {
            bulletSpawner.SetRate (isSum, value);
        }
    }
}
