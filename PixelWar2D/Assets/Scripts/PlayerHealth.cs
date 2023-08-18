using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Animator animator;

    public int health = 100;

    private void Awake()
    {
        animator = GetComponent<Animator>();
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
    }
}
