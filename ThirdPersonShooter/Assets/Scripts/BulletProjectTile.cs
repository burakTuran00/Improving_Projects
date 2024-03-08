using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectTile : MonoBehaviour
{
    /*[SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;*/

    private Rigidbody bulletRigidBody;

    private const float bulletSpeed = 35f;

    private void Awake()
    {
        bulletRigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        bulletRigidBody.velocity = transform.forward * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BulletTarget>() != null)
        {
            // hit green
        }
        else
        {
            // hit red;
        }

        Destroy(gameObject);
    }
}
