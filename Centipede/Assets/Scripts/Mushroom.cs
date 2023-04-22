using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public Sprite[] states;

    private SpriteRenderer spriteRenderer;

    private int health;

    public int points = 1;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = states.Length;
    }

    private void Damage()
    {
        health--;

        if (health > 0)
        {
            spriteRenderer.sprite = states[health];
        }
        else
        {
            Destroy (gameObject);
            GameManager.Instance.IncreaseScore (points);
        }
    }

    public void Heal()
    {
        health = states.Length;
        spriteRenderer.sprite = states[3];
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Dart"))
        {
            Damage();
        }
    }
}
