using System;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    private Animator animator;

    private PlayerMovement playerMovement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isShoting", true);
            playerMovement.movable = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("isShoting", false);
            playerMovement.movable = true;
        }
    }

   
}
