using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private PlayerMovement movement;

    public Sprite idle;

    public Sprite jump;

    public Sprite slide;

    private AnimatedSprite runSpirte;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponentInParent<PlayerMovement>();
        runSpirte = GetComponent<AnimatedSprite>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
        runSpirte.enabled = false;
    }

    private void LateUpdate()
    {
        runSpirte.enabled = movement.running;

        if (movement.jumping)
        {
            spriteRenderer.sprite = jump;
        }
        else if (movement.sliding)
        {
            spriteRenderer.sprite = slide;
        }
        else if (!movement.running)
        {
            spriteRenderer.sprite = idle;
        }
    }
}
