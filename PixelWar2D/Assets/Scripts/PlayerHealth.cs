using UnityEngine;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    private Animator animator;

    public int health = 100;

    public TextMeshProUGUI healthText;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        healthText.text = "x" + health.ToString();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Destroy (gameObject);
        }
        else
        {
            animator.SetTrigger("isHurting");
        }

        healthText.text = "x" + health.ToString();
    }
}
