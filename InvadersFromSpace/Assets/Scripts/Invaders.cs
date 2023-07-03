using UnityEngine;

public class Invaders : MonoBehaviour
{
    public Invader[] prefabs;

    public int rows = 5;

    public int columms = 8;

    private Vector3 direction = Vector2.right;

    public void Awake()
    {
    }

    private void CreatingInvaders()
    {
        for (int row = 0; row < rows; row++)
        {
            float width = 2.0f * (columms - 1);
            float height = 2.0f * (rows - 1);

            Vector2 centering = new Vector2(-width / 2, -height / 2);

            Vector3 rowPostion =
                new Vector3(centering.x, centering.y + (row * 1.250f), 0.0f);

            for (int col = 0; col < columms; col++)
            {
                Invader invader = Instantiate(prefabs[row], transform);
                Vector3 position = rowPostion;
                position.x += col * 1.250f;
                invader.transform.localPosition = position;
            }
        }
    }
}
