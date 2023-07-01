using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectCollisionPlayer : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    private int health = 100;

    public int enemyLaserDamage = 4;

    public int enemyDamage = 10;

    public float levelDelay = 1.0f;

    public int meteorDamage = 35;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyLaser"))
        {
            TakeDamage (enemyLaserDamage);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            Enemy e = other.gameObject.GetComponent<Enemy>();
            e.TakeDamage(e.health);

            TakeDamage (enemyDamage);
        }
        else if (other.CompareTag("Meteor"))
        {
            TakeDamage (meteorDamage);
            Destroy(other.gameObject, 0.5f);
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        healthText.text = "x" + health.ToString();

        if (health < 1)
        {
            FindObjectOfType<ProjectTile>().Lose();
            health = 0;
            StartCoroutine(ReloadLevel());
        }
    }

    private IEnumerator ReloadLevel()
    {
        yield return new WaitForSeconds(levelDelay);
        SceneManager.LoadScene(0);
    }
}
