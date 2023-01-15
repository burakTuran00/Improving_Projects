using UnityEngine;

public class Move : MonoBehaviour
{
    [Range(1, 10)]
    public float speed = 6f;

    private void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector2(hor, ver) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name.ToString());
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Worse"))
        {
            Debug.Log("Stay");
        }
    }
}
