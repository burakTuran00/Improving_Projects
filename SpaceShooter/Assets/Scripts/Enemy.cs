using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite[] enemies;

    public Sprite[] enemiesCrash;

    private int index;

    public int enemySpeed => Random.Range(5, 10);

    public int health;

    public int laserDamage = 5;

    public GameObject laser;

    public Transform fromShoot;

    private CircleCollider2D circleCollider2D;

    public float enemyLaserDelay => Random.Range(1.5f, 2.25f);

    private AudioSource soundEffect;

    public AudioClip laserEffect;

    public AudioClip crashEffect;

    private void Awake()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = Random.Range(3, 10);
        soundEffect = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GetIndexEnemy();
        InvokeRepeating(nameof(EnemyShoot), 0, enemyLaserDelay);
        soundEffect.clip = laserEffect;
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
            circleCollider2D.enabled = false;

            int crashIndex = Random.Range(0, enemiesCrash.Length);
            spriteRenderer.sprite = enemiesCrash[crashIndex];

            Destroy(this.gameObject, 0.75f);

            soundEffect.clip = crashEffect;
            soundEffect.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            TakeDamage (laserDamage);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("DestroyArea"))
        {
            Destroy (gameObject);
        }
    }
}
