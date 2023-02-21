using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private float health = 100;

    public Text healthText;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        healthText.text = "x" + health.ToString();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0f)
        {
            animator.SetTrigger("death");
        }

        healthText.text = "x" + health.ToString();
    }

    public void DestroyPlayer()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene(0);
    }
}
