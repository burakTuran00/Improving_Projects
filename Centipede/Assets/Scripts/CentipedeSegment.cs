using UnityEngine;

public class CentipedeSegment : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
}
