using UnityEngine;

public class ZombiHealth : MonoBehaviour
{
    private int health = 100;

    private PlayerHealth playerHealth;

    bool isDead = false;

    private Animator animator;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        animator = GetComponent<Animator>();
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(int damage)
    {
        BroadcastMessage("OnDamageTaken");

        health -= damage;

        if (health <= 0)
        {
            DieZombie();
        }
    }

    private void DieZombie()
    {
        if (isDead)
        {
            return;
        }

        isDead = true;
        animator.SetTrigger("Death");
        Destroy(gameObject, 1.2f);
    }
}
