using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    public float laserSpeed = 1.0f;

    public int damage = 5;

    private void Update()
    {
        transform.position += Vector3.up * laserSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy e = other.gameObject.GetComponent<Enemy>();
            e.TakeDamage (damage);
        }

        Destroy(this.gameObject);
    }
}
