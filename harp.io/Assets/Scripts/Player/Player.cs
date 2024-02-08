using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IProperties
{
    private const int MAX_VALUE = 10000;

    [SerializeField] private float speed = 10f;

    [SerializeField] private Joystick joystick;

    [SerializeField] private float shootRange;

    [SerializeField] private GameObject[] Enemies;

    private GameObject nearstEnemy;

    private float dist, nearstDist = MAX_VALUE;

    [SerializeField] private Pooler bulletPool;


    private void Update()
    {
        Move();
        Shoot();
    }

    public void Move()
    {
        float xMovement = joystick.Horizontal * speed * Time.deltaTime;
        float zMovement = joystick.Vertical * speed * Time.deltaTime;

        Vector3 newPosition = new Vector3(xMovement, 0f, zMovement);
        transform.position += newPosition;
    
    }

    public void Shoot()
    {
        FindNearstEnemy();
        bool shootable = (nearstDist <= shootRange) ? true : false;

        if(shootable)
        {
              
        }
        else
        {
            nearstDist = MAX_VALUE;
        }
    }

    private void FindNearstEnemy()
    {
        foreach(GameObject e in Enemies)
        {
            dist = Vector3.Distance(transform.position, e.transform.position);

            if (dist < nearstDist)
            {
                nearstEnemy = e;
                nearstDist = dist;
            }
        }
    }
}
