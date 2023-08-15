using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float bulletForce = 20.0f;

    private Rigidbody2D rb;

    private PlayerMovement playerMovement;

    private float directionWay;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();

        directionWay = playerMovement.transform.localScale.x * bulletForce;

        Destroy(gameObject, 1.75f);
    }

    private void Update()
    {
        rb.velocity = new Vector2(directionWay, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            Destroy(other.gameObject);
        }

        Destroy (gameObject);
    }
}
