using UnityEngine;

public class MushroomField : MonoBehaviour
{
    private BoxCollider2D area;

    public Mushroom prefab;

    [Header("Amount")]
    public int minAmount = 30;

    public int maxAmount = 60;

    public int amount;

    private void Awake()
    {
        area = GetComponent<BoxCollider2D>();
        amount = Random.Range(minAmount, maxAmount);
    }

    private void Start()
    {
        Generate();
    }

    private void Generate()
    {
        Bounds bounds = area.bounds;

        for (int i = 0; i < amount; i++)
        {
            Vector2 position = Vector2.zero;

            position.x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
            position.y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));

            Instantiate(prefab, position, Quaternion.identity, this.transform);
        }
    }
}
