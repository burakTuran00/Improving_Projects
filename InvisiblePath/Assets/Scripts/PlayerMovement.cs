using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private CircleCollider2D circleCollider2D;

    private Vector3 direction;

    public float speed = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
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
            //todo play
            Debug.Log("In");
        }
        else
        {
            //todo die
            Debug.Log("Out");
        }
    }
}
