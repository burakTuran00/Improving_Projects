using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 1.0f;

    public Vector3 direction = Vector3.up;

    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        player.laserActive = false;
        Destroy (gameObject);
    }
}
