using UnityEngine;
using UnityEngine.AI;

public class ZombieHealth : MonoBehaviour
{
    [Header("Zombie Health Settings")]
    public int health = 100;

    public bool isAlive = true;

    [Header("Elements")]
    private NavMeshAgent agent;

    private Animator animator;

    private new CapsuleCollider collider;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            ZombieDeath();
        }
    }

    private void ZombieDeath()
    {
        isAlive = false;
        animator.SetTrigger("Die");

        agent.speed = 0.0f;
        collider.enabled = false;

        Destroy(gameObject, 1.75f);
    }

    public bool IsAlive()
    {
        return isAlive;
    }
}
