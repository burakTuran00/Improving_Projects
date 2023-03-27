using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemyMoveSpeed = -1.0f;

    private Rigidbody2D rb;

    private Transform Direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(enemyMoveSpeed, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        enemyMoveSpeed = -enemyMoveSpeed;
        FlipEnemy();
    }

    private void FlipEnemy()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), 1.0f);
    }
}
