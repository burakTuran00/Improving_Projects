using UnityEngine;
using UnityEngine.AI;

public class ZombieHealth : MonoBehaviour
{
    public int health = 100;

    private bool isAlive = true;

    public void TakeDamageZombie(int damage)
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
        GetComponent<NavMeshAgent>().speed = 0.0f;
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Animator>().SetTrigger("Death");
        Destroy(gameObject, 2.5f);
    }

    public bool IsAlive()
    {
        return isAlive;
    }
}
