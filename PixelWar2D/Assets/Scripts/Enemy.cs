using System;
using UnityEditor.Animations;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;

    private Animator animator;

    private PlayerHealth playerHealth;

    [Header("Enemy Settings")]
    public float speed = 2.0f;

    public int damage = 25;

    public float walkableDistance = 10.0f;

    public float attackableDistance = 1f;

    public bool flip;

    public bool moveable = true;

    public float distanceToPlayer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        MoveToPlayer();
    }

    public void MoveToPlayer()
    {
        distanceToPlayer =
            Vector2.Distance(player.transform.position, transform.position);

        if ((distanceToPlayer <= walkableDistance) && moveable)
        {
            Vector3 scale = transform.localScale;

            if (player.transform.position.x > transform.position.x)
            {
                scale.x = Mathf.Abs(scale.x) * -1f * (flip ? -1 : 1);
                transform.Translate(speed * Time.deltaTime, 0f, 0f);
            }
            else if (player.transform.position.x < transform.position.x)
            {
                scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
                transform.Translate(-speed * Time.deltaTime, 0f, 0f);
            }

            animator.SetBool("isWalk", true);
            transform.localScale = scale;
        }
        else
        {
            animator.SetBool("isWalk", false);
        }
    }

    public void DamageToPlayer()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage (damage);
        }
    }
}
