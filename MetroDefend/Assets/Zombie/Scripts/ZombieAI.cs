using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    [Header("Zombie Settings")]
    public NavMeshAgent agent;

    public Animator animator;

    public GameObject target;

    public float walkingRange = 20.0f;

    public float lookingSpeed = 3.5f;

    private float distanceToTarget = Mathf.Infinity;

    private void ZombieMovement()
    {
        
    }
}
