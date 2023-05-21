using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerSpriteRenderer smallRenderer;

    public PlayerSpriteRenderer bigRenderer;

    private PlayerSpriteRenderer activeRenderer;

    private DeathAnimation deathAnimation;

    public bool big => bigRenderer.enabled;

    public bool small => smallRenderer.enabled;

    public bool death => deathAnimation.enabled;

    private void Awake()
    {
        deathAnimation = GetComponent<DeathAnimation>();
    }

    public void Hit()
    {
        if (big)
        {
            Shrink();
        }
        else
        {
            Death();
        }
    }

    private void Death()
    {
        smallRenderer.enabled = false;
        bigRenderer.enabled = false;
        deathAnimation.enabled = true;

        GameManager.Instance.ResetLevel(3.0f);
    }

    public void Grow()
    {
        smallRenderer.enabled = false;
        bigRenderer.enabled = true;

        activeRenderer = bigRenderer;
    }

    private void Shrink()
    {
        //todo
    }
}
