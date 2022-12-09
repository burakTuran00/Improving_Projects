using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 8f;

    Obstacle Obstacle_Ran = new Obstacle();

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


   

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }

    
}
