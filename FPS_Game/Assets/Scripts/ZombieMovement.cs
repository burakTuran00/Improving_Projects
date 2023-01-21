using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    public Animator animator;

    public NavMeshAgent agent;

    public GameObject target;

    private float distance;

    public Rigidbody rb;

    private void Update()
    {
        distance =
            Vector3.Distance(transform.position, target.transform.position);
        if (distance <= 8f)
        {
            animator.SetBool("Run", true);
            agent.SetDestination(target.transform.position);
            if (distance <= 2f)
            {
                animator.SetBool("Attack", true);
            }
            else
            {
                animator.SetBool("Attack", false);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Debug.Log("hit");
        }
    }
}
