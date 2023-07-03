using UnityEngine;

public class Invaders : MonoBehaviour
{
    [Header("Invaders")]
    public Invader[] prefabs;

    public float speed = 1.0f;

    public Vector3 direction = Vector3.right;

    public Vector3 initialPosition { get; private set; }

    public System.Action<Invader> killed;

    public int AmountKilled { get; private set; }

    public int AmountAlive => TotalAmount - AmountKilled;

    public int TotalAmount => rows * columns;

    public float PercentKilled => (float) AmountKilled / (float) TotalAmount;

    [Header("Grid")]
    public int rows = 5;

    public int columns = 11;

    private void Awake()
    {
        AdjustPositions();
    }

    private void Update()
    {
        Movement();
    }

    private void AdjustPositions()
    {
        for (int i = 0; i < rows; i++)
        {
            float width = 2f * (columns - 1);
            float height = 2f * (rows - 1);

            Vector2 centerOffset = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition =
                new Vector3(centerOffset.x, centerOffset.y + (2f * i), 0f);

            for (int j = 0; j < columns; j++)
            {
                Invader invader = Instantiate(prefabs[i], transform);

                Vector3 position = rowPosition;
                position.x += 2f * j;
                invader.transform.localPosition = position;
            }
        }
    }

    private void Movement()
    {
       

        transform.position += direction * speed * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (direction == Vector3.right && invader.position.x >= (rightEdge.x - 1f))
            {
                AdvanceRow();
                break;
            }
            else  if (direction == Vector3.left && invader.position.x <= (leftEdge.x + 1f))
            {
                AdvanceRow();
                break;
            }
        }
    }

    private void AdvanceRow()
    {
       
        direction.x *= -1;

        
        Vector3 position = transform.position;
        position.y -= 1f;

        transform.position = position;
    }

    private void OnInvaderKilled(Invader invader)
    {
        invader.gameObject.SetActive(false);
        AmountKilled++;
        killed(invader);
    }
}
