using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;

    public TextMeshProUGUI healthText;

    private bool playerAlive = true;

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
        Debug.Log("Died");
    }

    public bool IsPlayerAlive()
    {
        return playerAlive;
    }
}
