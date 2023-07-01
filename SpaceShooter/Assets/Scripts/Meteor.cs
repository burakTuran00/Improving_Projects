using UnityEngine;

public class Meteor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite[] meteors;

    public float meteorSpeed => Random.Range(3, 12);

    public int health => Random.Range(1, 5);

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        GetIndexMeteor();
    }

    private void Update()
    {
        MeteorMovement();
    }

    private void GetIndexMeteor()
    {
        int index = Random.Range(0, meteors.Length);
        spriteRenderer.sprite = meteors[index];
    }

    private void MeteorMovement()
    {
        transform.position += Vector3.down * meteorSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward);
    }
}
