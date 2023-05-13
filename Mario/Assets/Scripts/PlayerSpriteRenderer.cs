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
    }
}
