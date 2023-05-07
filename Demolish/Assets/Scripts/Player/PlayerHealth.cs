using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;

    public TextMeshProUGUI healthText;

    private GameManager gameManager;

    private bool playerAlive = true;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void TakeDamagePlayer(int damage)
    {
        health -= damage;
        healthText.text = health.ToString();

        if (health <= 0)
        {
            health = 0;
            healthText.text = health.ToString();

            playerAlive = false;

            PlayerDie();
        }
    }

    private void PlayerDie()
    {
        if (gameManager == null)
        {
            return;
        }

        gameManager.LoadUILevel();
    }

    public bool IsPlayerAlive()
    {
        return playerAlive;
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
