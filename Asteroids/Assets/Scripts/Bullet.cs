using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 500.0f;

    public float maxLifeTime = 10.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction)
    {
        rb.AddForce(direction * speed);

        Destroy (gameObject, maxLifeTime);
    }
}
