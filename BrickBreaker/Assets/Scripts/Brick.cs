using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }

    public Sprite[] state;

    public int health { get; private set; }

    public bool unbreakable;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (!unbreakable)
        {
            health = state.Length;
            spriteRenderer.sprite = state[health - 1];
        }
    }

    private void Hit()
    {
        if (unbreakable)
        {
            return;
        }

        health--;

        if (health <= 0)
        {
            this.gameObject.SetActive(false);
            Destroy (gameObject);
        }
        else
        {
            spriteRenderer.sprite = state[health - 1];
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Hit();
        }
    }
}
