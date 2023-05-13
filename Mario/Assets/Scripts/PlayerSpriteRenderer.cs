using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private PlayerMovement movement;

    public Sprite[] run;

    public Sprite idle;

    public Sprite jump;

    public Sprite slide;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponentInParent<PlayerMovement>();
    }

    private void LateUpdate()
    {
        if (movement.jumping)
        {
            spriteRenderer.sprite = jump;
        }
        else if (movement.sliding)
        {
            spriteRenderer.sprite = slide;
        }
        else if (movement.running)
        {
        }
        else
        {
            spriteRenderer.sprite = idle;
        }
    }

    public void Run()
    {
        
    }
}
