using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemyMoveSpeed = 1.0f;

    private Rigidbody2D rb;

    public float directionX = 1.0f;

    private void Awake()
    {
        transform.Rotate(new Vector3(0f, 180f, 0f));
        rb = GetComponent<Rigidbody2D>();
        directionX = transform.localScale.x;
    }

    private void Update()
    {
        rb.velocity = new Vector2(directionX * enemyMoveSpeed, 0f);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        FlipEnemy();
    }

    private void FlipEnemy()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), 1.0f);
        directionX = transform.localScale.x;
    }
}
