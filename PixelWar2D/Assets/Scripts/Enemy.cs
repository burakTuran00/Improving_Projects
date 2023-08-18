using UnityEditor.Animations;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;

    private Animator animator;

    [Header("Enemy Settings")]
    public float speed = 2.0f;

    public int Damage = 25;

    public float walkableDistance = 10.0f;

    public bool flip;

    public bool moveable = true;

    private float distanceToPlayer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
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
            else
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
}
