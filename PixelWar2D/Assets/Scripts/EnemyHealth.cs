using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;

    public float deathDelay = 1.0f;

    private Animator animator;

    private Enemy enemy;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
    }

  

    public void TakeDamage(int amount)
    {
        health -= amount;
        

        if (health <= 0)
        {
            StartCoroutine(Die());
        }
        else
        {
            animator.SetTrigger("isHit");
        }
    }

    private IEnumerator Die()
    {
        enemy.moveable = false;
        animator.SetTrigger("isDead");
        yield return new WaitForSeconds(deathDelay);
        gameObject.SetActive(false);
    }
}
