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

    public void Generate()
    {
        Bounds bounds = area.bounds;

        for (int i = 0; i < amount; i++)
        {
            Vector2 position = Vector2.zero;

            position.x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
            position.y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));

           Mushroom mushroom = Instantiate(prefab, position, Quaternion.identity, this.transform);
           
        }
    }

    public void ClearField()
    {
        Mushroom[] mushrooms = FindObjectsOfType<Mushroom>();

        foreach (Mushroom mushroom in mushrooms)
        {
            Destroy(mushroom.gameObject);
        }

    }

    public void Heal()
    {
        Mushroom[] mushrooms = FindObjectsOfType<Mushroom>();

        foreach (Mushroom mushroom in mushrooms)
        {
            mushroom.Heal();
        }
    }
}
