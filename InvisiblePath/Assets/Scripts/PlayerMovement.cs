using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private Exit exit;

    private CircleCollider2D circleCollider2D;

    private Vector3 direction;

    public float speed = 1f;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        exit = FindObjectOfType<Exit>();
    }

    private void Update()
    {
        Move();
        DetectCollision();
    }

    private void Move()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        //rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
        transform.position += direction * speed * Time.deltaTime;
    }

    private void DetectCollision()
    {
        if (circleCollider2D.IsTouchingLayers(LayerMask.GetMask("Area")))
        {
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        StartCoroutine(exit.LoadCurrentLevel());
    }
}
