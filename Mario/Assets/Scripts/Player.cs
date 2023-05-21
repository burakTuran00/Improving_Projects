using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerSpriteRenderer smallRenderer;

    public PlayerSpriteRenderer bigRenderer;

    private PlayerSpriteRenderer activeRenderer;

    private DeathAnimation deathAnimation;

    private CapsuleCollider2D capsuleCollider2D;

    public bool big => bigRenderer.enabled;

    public bool small => smallRenderer.enabled;

    public bool death => deathAnimation.enabled;

    public bool starpower { get; private set; }

    private void Awake()
    {
        deathAnimation = GetComponent<DeathAnimation>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    public void Hit()
    {
        if (!starpower && !death)
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

        capsuleCollider2D.size = new Vector2(0.9f, 1.9f);
        capsuleCollider2D.offset = new Vector2(0f, 0f);

        StartCoroutine(ScaleAnimation());
    }

    private void Shrink()
    {
        smallRenderer.enabled = true;
        bigRenderer.enabled = enabled;

        activeRenderer = smallRenderer;

        capsuleCollider2D.size = new Vector2(0.7f, 0.95f);
        capsuleCollider2D.offset = new Vector2(0f, -0.5f);

        StartCoroutine(ScaleAnimation());
    }

    private IEnumerator ScaleAnimation()
    {
        float elapsed = 0;
        float duration = 0.5f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            if (Time.frameCount % 4 == 0)
            {
                smallRenderer.enabled = !smallRenderer.enabled;
                bigRenderer.enabled = !bigRenderer.enabled;
            }

            yield return null;
        }

        smallRenderer.enabled = false;
        bigRenderer.enabled = false;

        activeRenderer.enabled = true;
    }

    public void Starpower()
    {
    }
}
