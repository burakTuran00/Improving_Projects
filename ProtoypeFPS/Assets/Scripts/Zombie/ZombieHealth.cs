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

    private AudioSource audioSource;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider>();
        audioSource = GetComponent<AudioSource>();

        agent.stoppingDistance = 4f;
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
        audioSource.Play();

        isAlive = false;
        animator.SetTrigger("Die");

        agent.speed = 0.0f;
        collider.enabled = false;

        Invoke(nameof(IsActive), 1.75f);
    }

    private void IsActive()
    {
        gameObject.SetActive(false);
    }

    public bool IsAlive()
    {
        return isAlive;
    }
}
