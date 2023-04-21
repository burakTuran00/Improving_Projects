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
    public float speed = 20f;

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
            segment.centipede = this;
            segments.Add (segment);
        }

        for (int i = 0; i < segments.Count; i++)
        {
            CentipedeSegment segment = segments[i];
            segment.ahead = GetSegmentAt(i-1);
            segment.behind = GetSegmentAt(i+1);
        }
    }

    private CentipedeSegment GetSegmentAt(int index)
    {
        if (index >= 0 && index < segments.Count)
        {
            return segments[index];
        }
        else
        {
            return null;
        }
    }

    private Vector2 GridPosition(Vector2 position)
    { 
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);
        return position;
    }
}
