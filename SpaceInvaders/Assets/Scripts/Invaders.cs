using UnityEngine;

public class Invaders : MonoBehaviour
{
    public Invader[] prefabs;

    public int rows = 5;

    public int columms = 11;

    public float speed = 1.0f;

    private Vector3 direction = Vector2.right;

    public void Awake()
    {
        for (int row = 0; row < rows; row++)
        {
            float width = 2.0f * (columms - 1);
            float height = 2.0f * (rows - 1);

            Vector2 centering = new Vector2(-width / 2, -height / 2);

            Vector3 rowPostion =
                new Vector3(centering.x, centering.y + (row * 2.0f), 0.0f);

            for (int col = 0; col < columms; col++)
            {
                Invader invader = Instantiate(prefabs[row], transform);
                Vector3 position = rowPostion;
                position.x += col * 2.0f;
                invader.transform.localPosition = position;
            }
        }
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (
                direction == Vector3.right &&
                invader.position.x >= (rightEdge.x - 1)
            )
            {
                AdvancedRow();
            }
            else if (
                direction == Vector3.left &&
                invader.position.x <= (leftEdge.x + 1)
            )
            {
                AdvancedRow();
            }
        }
    }

    private void AdvancedRow()
    {
        direction.x *= -1;

        Vector3 position = this.transform.position;
        position.y -= 1;

        this.transform.position = position;
    }
}
