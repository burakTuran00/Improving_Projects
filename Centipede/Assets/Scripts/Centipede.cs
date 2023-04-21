using System.Collections.Generic;
using UnityEngine;

public class Centipede : MonoBehaviour
{
    private List<CentipedeSegment> segments = new List<CentipedeSegment>();

    public CentipedeSegment segmentPrefab;

    [Header("Sprites")]
    public Sprite headSprite;

    public Sprite bodySprite;

    public int size = 12;

    private void Start()
    {
        Respawn();
    }

    private void Respawn()
    {
        foreach (CentipedeSegment segment in segments)
        {
            Destroy(segment.gameObject);
        }

        segments.Clear();

        for (int i = 0; i < size; i++)
        {
            Vector2 position = GridPosition(transform.position) + (Vector2.left * i);
            CentipedeSegment segment = Instantiate(segmentPrefab, position, Quaternion.identity);
            segment.spriteRenderer.sprite = (i == 0) ? headSprite : bodySprite; 
            segments.Add (segment);
        }
    }

    private Vector2 GridPosition(Vector2 position)
    { 
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);
        return position;
    }
}
