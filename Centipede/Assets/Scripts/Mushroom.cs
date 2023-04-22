using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public Sprite[] states;

    private SpriteRenderer spriteRenderer;

    private int health;

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
