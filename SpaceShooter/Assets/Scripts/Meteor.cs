using UnityEngine;

public class Meteor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite[] meteors;

    public float meteorSpeed = 1.0f;

    public int helath => Random.Range(1, 5);

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        MeteorMovement();
    }

    private void MeteorMovement()
    {
        transform.position += Vector3.down * meteorSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward);
    }
}
