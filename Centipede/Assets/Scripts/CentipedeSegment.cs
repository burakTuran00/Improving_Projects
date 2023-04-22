using UnityEngine;

public class CentipedeSegment : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }

    public Centipede centipede { get; set; }

    public CentipedeSegment ahead { get; set; }

    public CentipedeSegment behind { get; set; }

    public bool isHead => ahead == null;

    private Vector2 direction = Vector2.right + Vector2.down;

    private Vector2 targerPosition;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        targerPosition = transform.position;
    }

    private void Update()
    {
        if (isHead && Vector2.Distance(transform.position, targerPosition) < 0.1f)
        {
            UpdateHeadSegment();
        }

        Vector2 currentPosition = transform.position;
        float speed = centipede.speed * Time.deltaTime;
        transform.position =
            Vector2.MoveTowards(currentPosition, targerPosition, speed);

        Vector2 movementDirection =
            (targerPosition - currentPosition).normalized;
        float angle = Mathf.Atan2(movementDirection.y, movementDirection.x);
        transform.rotation =
            Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    public void UpdateHeadSegment()
    {
        Vector2 gridPosition = GridPosition(transform.position);

        targerPosition = gridPosition;
        targerPosition.x += direction.x;

        if (Physics2D.OverlapBox(targerPosition, Vector2.zero, 0f, centipede.collisionMask))
        {
            direction.x = - direction.x;

            targerPosition.x = gridPosition.x;
            targerPosition.y = gridPosition.y + direction.y;

            Bounds homeBounds = centipede.homeArea.bounds;

            if ((direction.y == 1 && targerPosition.y > homeBounds.max.y) || 
                (direction.y == -1 && targerPosition.y < homeBounds.min.y))
            {
                direction.y = -direction.y;
                targerPosition.y = gridPosition.y + direction.y;
            }
        }

        if (behind != null)
        {
            behind.UpdateBodySegment();
        }
    }

    private void UpdateBodySegment()
    {
        targerPosition =GridPosition(ahead.transform.position);
        direction = ahead.direction;

        if (behind != null)
        {
            behind.UpdateBodySegment();
        }
    }
    
    private Vector2 GridPosition(Vector2 position)
    { 
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);
        return position;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
      if(other.gameObject.layer == LayerMask.NameToLayer("Dart") && other.collider.enabled)
      {
        other.collider.enabled = false;
        centipede.Remove(this);
      }   
      else if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
      {
        GameManager.Instance.ResetRound();
        return;
      }
    }
}
