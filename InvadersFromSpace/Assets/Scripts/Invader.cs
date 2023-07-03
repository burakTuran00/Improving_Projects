using UnityEngine;

public class Invader : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite[] animationSprites;

    private int animationFrame;

    public int animationTime;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = animationSprites[0];
    }

    private void Start()
    {
        
    }

    private void AnimateSprite()
    {
        animationFrame++;

        if (animationFrame >= animationSprites.Length)
        {
            animationFrame = 0;
        }

        spriteRenderer.sprite = animationSprites[animationFrame];
    }
}
