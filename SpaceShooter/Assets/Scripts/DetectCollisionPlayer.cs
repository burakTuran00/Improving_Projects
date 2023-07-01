using TMPro;
using UnityEngine;

public class DetectCollisionPlayer : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    private int health = 100;

    public int enemyLaserDamage = 4;

    public int enemyDamage = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyLaser"))
        {
            TakeDamage (enemyLaserDamage);
        }
        else if (other.CompareTag("Enemy"))
        {
            TakeDamage (enemyDamage);
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        healthText.text = "x" + health.ToString();

        if (health < 1)
        {
            //todo
        }
    }
}
