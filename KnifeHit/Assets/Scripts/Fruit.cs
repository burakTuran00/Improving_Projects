using UnityEngine;

public class Fruit : MonoBehaviour
{
    private int spriteIndex;

    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.sprite = sprites[GetRandomIndex()];
    }

    private int GetRandomIndex()
    {
        spriteIndex = Random.Range(0, sprites.Length);
        return spriteIndex;
    }
}
