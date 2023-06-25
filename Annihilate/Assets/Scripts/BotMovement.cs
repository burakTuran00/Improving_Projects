using UnityEngine;
using UnityEngine.AI;

public class BotMovement : MonoBehaviour
{
    public float speed = 1.0f;

    private NavMeshAgent agent;

    private PlayerMovement playerMovement;

    private float distanceToTarget = Mathf.Infinity;

    public float rangeWalkable = 5f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        agent.speed = 0;
    }

    private void Update()
    {
        if (playerMovement != null)
        {
            distanceToTarget =
                Vector3
                    .Distance(playerMovement.transform.position,
                    transform.position);
            transform.LookAt(playerMovement.transform);

            if (distanceToTarget <= rangeWalkable)
            {
                agent.speed = speed;
                agent.SetDestination(playerMovement.transform.position);
            }
        }
    }
}
