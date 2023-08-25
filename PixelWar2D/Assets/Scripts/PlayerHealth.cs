using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Animator animator;

    public int health = 100;

    public TextMeshProUGUI healthText;

    private GameManager gameManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        healthText.text = "x" + health.ToString();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            gameManager.RestartLevel();
        }
        else
        {
            animator.SetTrigger("isHurting");
        }

        healthText.text = "x" + health.ToString();
    }

    public void IncreaseHealth(int amount)
    {
        health += amount;
        healthText.text = "x" + health.ToString();
    }
}
