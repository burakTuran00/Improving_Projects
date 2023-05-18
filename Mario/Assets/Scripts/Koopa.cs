using UnityEngine;

public class Koopa : MonoBehaviour
{
    public Sprite shellSprite;

    public float shellSpeed = 12.0f;

    private bool shelled;

    private bool pushed;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !shelled)
        {
            Player player = other.gameObject.GetComponent<Player>();

            if (other.transform.DotTest(transform, Vector2.down))
            {
                EnterShell();
            }
            else
            {
                player.Hit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && shelled)
        {
            if (!pushed)
            {
                Vector2 direction =new Vector2(transform.position.x - other.transform.position.x, 0f);
                PushShell(direction);
            }
            else
            {
                Player player = other.GetComponent<Player>();
                player.Hit();
            }
        }
    }

    private void EnterShell()
    {
        shelled = true;

        GetComponent<EntityMovement>().enabled = false;
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = shellSprite;
    }

    private void PushShell(Vector2 direction)
    {
        pushed = true;

        GetComponent<Rigidbody2D>().isKinematic = true;
        
        EntityMovement entityMovement = GetComponent<EntityMovement>();
        entityMovement.direction = direction.normalized;
        entityMovement.speed = shellSpeed;
        entityMovement.enabled = true;

        gameObject.layer = LayerMask.NameToLayer("Shell");
    }
}
