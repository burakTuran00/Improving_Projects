using UnityEngine;
using TMPro;
public class ShootingSystem : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform shootingPosition;

    private Animator animator;

    private PlayerMovement playerMovement;

    private int ammo = 30;

    public TextMeshProUGUI ammoText;

    private bool shootable => ammo > 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();

        ammoText.text = ammo.ToString();
    }

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && playerMovement.IsJumping && shootable)
        {
            Instantiate(bulletPrefab, shootingPosition.position , Quaternion.identity);

            ammo--;

            if (ammo < 1)
            {
                ammo = 0;
            }

            ammoText.text = ammo.ToString();

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