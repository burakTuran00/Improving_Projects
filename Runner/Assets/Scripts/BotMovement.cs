using UnityEngine;
using UnityEngine.AI;

public class BotMovement : MonoBehaviour
{
    private NavMeshAgent agent;

    public GameObject FinishLine;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        agent.SetDestination(FinishLine.transform.position);
        this.transform.LookAt(FinishLine.transform);
    }
}
