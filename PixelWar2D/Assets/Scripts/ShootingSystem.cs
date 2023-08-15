using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform shootingPosition;

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
        if (Input.GetMouseButtonDown(0) && playerMovement.IsJumping)
        {
            Instantiate(bulletPrefab, shootingPosition.position , Quaternion.identity);
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
