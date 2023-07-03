using UnityEngine;

public class Laser : MonoBehaviour
{
    public Vector3 direciton;

    public float speed = 1.0f;

    public float laserDestroyTime = 1.0f;

    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        transform.position += direciton * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LaserReloaded") || other.CompareTag("Invader") || other.CompareTag("Bunker"))
        {
            player.isLaserActive = false;
            Destroy(gameObject);
        }
    }
}
