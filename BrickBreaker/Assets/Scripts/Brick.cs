using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer spriteRenderer {get;private set}
    public int health { get; private set; }

    private void Awake() {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
