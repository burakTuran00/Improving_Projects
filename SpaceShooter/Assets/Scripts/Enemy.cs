using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite[] enemies;

    private int index;

    public int enemySpeed => Random.Range(5, 15);

    public int health;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        health = Random.Range(3, 10);
    }

    private void Start()
    {
        GetIndexEnemy();
    }

    private void Update()
    {
        EnemyMovement();
    }

    private void GetIndexEnemy()
    {
        index = Random.Range(0, enemies.Length);
        spriteRenderer.sprite = enemies[index];
    }

    private void EnemyMovement()
    {
        transform.position += Vector3.down * enemySpeed * Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
