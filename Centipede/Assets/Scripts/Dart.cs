using UnityEngine;

public class Dart : MonoBehaviour
{
    private Rigidbody2D rb;

    private new Collider2D collider;

    private Transform parent;

    public float speed = 1.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();

        rb.bodyType = RigidbodyType2D.Kinematic;
        collider.enabled = false;

        parent = transform.parent;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && rb.isKinematic)
        {
            transform.SetParent(null);
            rb.bodyType = RigidbodyType2D.Dynamic;
            collider.enabled = true;
        }
    }

    private void FixedUpdate()
    {
        if (!rb.isKinematic)
        {
          rb.MovePosition(rb.position + Vector2.up * speed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        transform.SetParent(parent);
        transform.localPosition = new Vector3(0f,0.5f,0f);
        rb.bodyType = RigidbodyType2D.Kinematic;
        collider.enabled = false;
    }
}
