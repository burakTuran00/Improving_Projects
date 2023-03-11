using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    private Vector3 direction;

    public float speed = 4f;

    private float leftEdge;

    private void Awake()
    {
        direction = Vector3.left;
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        //transform.Translate(direction * speed * Time.deltaTime);  // You can choose this. Actually I didn't find difference.
        if (transform.position.x <= leftEdge)
        {
            Destroy (gameObject);
        }
    }
}
