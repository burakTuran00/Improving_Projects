using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb { get; private set; }

    public float ballForce = 500.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Invoke(nameof(SetRandomTrajectory), 1.0f);
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1.0f;

        rb.AddForce(force.normalized * ballForce);
    }
}
