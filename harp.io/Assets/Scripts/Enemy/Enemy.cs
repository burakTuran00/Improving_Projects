using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IProperties
{
    #region Variables
    [SerializeField] private NavMeshAgent navMeshAgent;

    [SerializeField] private Player player;

    [SerializeField] private float speed;

    [SerializeField] private float range;

    [SerializeField] private float dist;

    private bool attackable;

    #endregion

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        dist = Vector3.Distance(transform.position, player.transform.position);
        dist = Mathf.Abs(Mathf.RoundToInt(dist));

        attackable = (dist <= range) ? true : false;

        if (!attackable)
        {
            navMeshAgent.speed = 0;
        }
        else
        {
            navMeshAgent.speed = speed;
            navMeshAgent.SetDestination(player.transform.position);
            transform.LookAt(player.transform);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void Shoot()
    {
       
    }

   
}
