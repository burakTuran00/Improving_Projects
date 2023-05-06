using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;

    public TextMeshProUGUI healthText;

    public void TakeDamagePlayer(int damage)
    {
        health -= damage;
        healthText.text = health.ToString();

        if (health <= 0)
        {
            healthText.text = health.ToString();
            PlayerDie();
        }
    }

    private void PlayerDie()
    {
        Destroy(this.gameObject);
    }

    public void TakeHealth(int healthKit)
    {
        health += healthKit;
        healthText.text = health.ToString();

        if (health >= 100)
        {
            health = 100;
            healthText.text = health.ToString();
        }
    }
}
