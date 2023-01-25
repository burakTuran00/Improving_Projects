using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject target;

    public Animator animator;

    private float distance = 0f;

    PlayerHealthy playerHealthy = new PlayerHealthy();

    private void Start()
    {
        InvokeRepeating(nameof(MeasureDistance), 1f, .5f);
    }

    private void Update()
    {
        if (distance <= 15f && distance > 1.5f)
        {
            agent.speed = 3f;
            animator.SetBool("Walk", true);
            agent.SetDestination(target.transform.position);
        }
        else
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Attack", false);
            agent.speed = 0f;
        }
    }

    void MeasureDistance()
    {
        distance =
            Vector3.Distance(target.transform.position, transform.position);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Debug.Log(other.transform.name.ToString());
            animator.SetBool("Attack", true);
            playerHealthy.Damage(5);
        }
    }

  /*  private void OnCollisionExit(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            animator.SetBool("Attack", false);
        }
    }*/
}
