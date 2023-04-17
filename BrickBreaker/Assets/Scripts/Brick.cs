using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }

    public Sprite[] state;

    public int health { get; private set; }

    public int points = 100;

    public bool unbreakable;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ResetBrick();
    }

    public void ResetBrick()
    {
        this.gameObject.SetActive(true);

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
        }
        else
        {
            spriteRenderer.sprite = state[health - 1];
        }

        FindObjectOfType<GameManager>().Hit(this);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Hit();
        }
    }
}
