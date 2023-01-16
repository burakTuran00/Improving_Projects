using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthy : MonoBehaviour
{
    public int playerHealth = 100;

    public Text playerText;

    public void Damage(int damage)
    {
        playerHealth-=damage;
        Debug.Log(playerHealth.ToString());
        if (playerHealth <= 0)
        {
            Debug.Log("Player is dead.");
            Time.timeScale = 0f;
        }
    }
}
