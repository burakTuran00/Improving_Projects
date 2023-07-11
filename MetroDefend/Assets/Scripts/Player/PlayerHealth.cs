using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private GameManager gameManager;

    public int health = 100;

    public TextMeshProUGUI healthText;

    private bool playerAlive = true;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void TakeDamagePlayer(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;
            playerAlive = false;
            PlayerDie();
        }

        healthText.text = "x" + health.ToString();
    }

    private void PlayerDie()
    {
        if (gameManager == null)
        {
            return;
        }

        gameManager.RestartLevel();
    }

    public bool IsPlayerAlive()
    {
        return playerAlive;
    }
}
