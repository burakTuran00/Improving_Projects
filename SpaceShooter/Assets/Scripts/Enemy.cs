using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite[] enemies;

    private int index;

    public int enemySpeed => Random.Range(5, 15);

    public int health;

    public int laserDamage = 5;

    public GameObject laser;

    public Transform fromShoot;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = Random.Range(3, 10);
    }

    private void Start()
    {
        GetIndexEnemy();
        InvokeRepeating(nameof(EnemyShoot), 1f, 1f);
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

    private void EnemyShoot()
    {
        Instantiate(laser, fromShoot.position, Quaternion.identity);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 1)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            TakeDamage (laserDamage);
            Destroy(other.gameObject);
        }
    }
}
