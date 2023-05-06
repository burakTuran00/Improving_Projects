using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    private Animator animator;

    private NavMeshAgent agent;

    private ZombieHealth zombieHealth;

    public GameObject target;

    public float rangeWalk = 14f;

    private float distanceToTarget = Mathf.Infinity;

    public float lookingSpeed = 3.5f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        zombieHealth = GetComponent<ZombieHealth>();
    }

    private void Update()
    {
        ZombieMovement();
    }

    private void ZombieMovement()
    {
        LookToTarget();

        distanceToTarget =
            Vector3.Distance(target.transform.position, transform.position);

        if (distanceToTarget <= rangeWalk)
        {
            agent.speed = 2.0f;

            if (distanceToTarget >= agent.stoppingDistance)
            {
                animator.SetBool("Attack", false);
                animator.SetBool("Move",true);
            }
            else if (distanceToTarget <= agent.stoppingDistance)
            {
                animator.SetBool("Attack", true);
            }
            
            agent.SetDestination(target.transform.position);
        }
        else
        {
            agent.speed = 0.0f;
            animator.SetBool("Move",false);
            return;
        }
    }

    private void LookToTarget()
    {
        Vector3 direction =
            (target.transform.position - transform.position).normalized;
        Quaternion lookRotation =
            Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation =
            Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookingSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeWalk);
    }
}
