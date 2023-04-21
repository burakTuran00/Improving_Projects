using UnityEngine;

public class CentipedeSegment : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }

    public Centipede centipede { get; set; }

    public CentipedeSegment ahead { get; set; }

    public CentipedeSegment begind { get; set; }

    public bool isHead => ahead == null;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
