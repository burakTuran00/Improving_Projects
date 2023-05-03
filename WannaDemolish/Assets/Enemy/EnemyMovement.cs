using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform target;

    private float followRange = 7f;

    private float distancetarget = Mathf.Infinity;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        distancetarget = Vector3.Distance(target.position, transform.position);

        if (distancetarget <= followRange)
        {
            agent.SetDestination(target.position);
        }
    }
}
