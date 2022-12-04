using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed = 200f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        ResetPosition();
    }
    public void AddStartingForce()
    {
        float x = Random.value < .5f ? -1f : 1f;
        float y = Random.value < .5f ? Random.Range(-1f, -0.5f) : Random.Range(.5f, 1f);
        rb.AddForce(new Vector2(x, y) * this.speed);  
    }
    public void ResetPosition()
    {
        rb.position = Vector2.zero;
        rb.velocity = Vector2.zero;

        AddStartingForce();
    }

    public void AddForce(Vector2 force)
    {
        rb.AddForce(force); 
    }
  
}
