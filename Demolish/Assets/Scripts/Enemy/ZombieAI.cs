using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    private NavMeshAgent zombieAgent;

    private Animator animator;

    public Transform target;

    private ZombiHealth zombiHealth;

    bool isProvoked = false;

    float distanceToTarget = Mathf.Infinity;

    public float range = 10f;

    public float lookRotSpeed = 5f;

    private void Awake()
    {
        zombieAgent = GetComponent<NavMeshAgent>();
        zombiHealth = GetComponent<ZombiHealth>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (zombiHealth.IsDead())
        {
            zombieAgent.enabled = false;
            enabled = false;
        }

        distanceToTarget =
            Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= range)
        {
            isProvoked = true;
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();

        if (distanceToTarget >= zombieAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceToTarget <= zombieAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        animator.SetBool("Attack", true);
    }

    private void ChaseTarget()
    {
        animator.SetBool("Attack", false);
        animator.SetTrigger("Move");
        zombieAgent.SetDestination(target.position);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation =
            Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation =
            Quaternion
                .Slerp(transform.rotation,
                lookRotation,
                Time.deltaTime * lookRotSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
