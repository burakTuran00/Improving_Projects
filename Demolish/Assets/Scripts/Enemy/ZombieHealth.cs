using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int health = 100;

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
        GetComponent<Animator>().SetTrigger("Death"); // Trigger to death animation
        Destroy(gameObject, 1.5f);
    }
}
