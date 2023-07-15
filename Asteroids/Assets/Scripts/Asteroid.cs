using UnityEngine;

[RequireComponent(typeof (SpriteRenderer))]
[RequireComponent(typeof (Rigidbody2D))]
public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;

    public float size = 1.0f;

    public float misSize = 0.5f;

    public float maxSize = 1.5f;

    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360.0f);
        transform.localScale = Vector3.one * size;

        rb.mass = size;
    }
}
