using UnityEngine;

public class Fruit : MonoBehaviour
{
    private int spriteIndex;

    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;

    private ParticleSystem effect;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        effect = GetComponentInChildren<ParticleSystem>();
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

    public void CallParticleSystem()
    {
        effect.Play();
    }
}
