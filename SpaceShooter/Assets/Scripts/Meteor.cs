using UnityEngine;

public class Meteor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite[] meteors;

    public float meteorSpeed => Random.Range(3, 12);

    public float rotationSpeed => Random.Range(1, 2);

    public int health;

    public int playerLaserDamage = 3;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = Random.Range(1, 4);
    }

    private void Start()
    {
        GetIndexMeteor();
    }

    private void Update()
    {
        MeteorMovement();
    }

    private void GetIndexMeteor()
    {
        int index = Random.Range(0, meteors.Length);
        spriteRenderer.sprite = meteors[index];
    }

    private void MeteorMovement()
    {
        transform.position += Vector3.down * meteorSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward * rotationSpeed);
    }

    private void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 1)
        {
            Destroy (gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            TakeDamage (playerLaserDamage);
            Destroy(other.gameObject);
        }
    }
}
