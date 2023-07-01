using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite[] enemies;

    private int index;

    public int GetIndexEnemy()
    {
        index = Random.Range(0, enemies.Length);
        return index;
    }
}
