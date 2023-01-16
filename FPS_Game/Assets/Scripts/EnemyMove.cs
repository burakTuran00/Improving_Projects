using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public int enemyDamage = 5;

    public GameObject player;

    public NavMeshAgent agent;

    PlayerHealthy playerHealthy = new PlayerHealthy();

    private void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            playerHealthy.Damage (enemyDamage);
        }
    }
}
