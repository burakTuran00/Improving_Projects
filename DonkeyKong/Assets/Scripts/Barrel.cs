using UnityEngine;

public class Barrel : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 1.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            rb.AddForce(other.transform.right * speed, ForceMode2D.Impulse);
        }
    }
}
