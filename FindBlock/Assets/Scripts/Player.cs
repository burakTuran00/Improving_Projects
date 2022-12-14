using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 direction = Vector2.zero;
    public float speed = .5f;
    private int score = 0;

    public Transform food;
    public Text Score_Text;

    private void RandomPosition()
    {
        float x_Rand = Random.Range(-18, 18);
        float y_Rand = Random.Range(-9, 9);

        food.transform.position = new Vector2(Mathf.Round(x_Rand), Mathf.Round(y_Rand));

        Score_Text.text = "x" + score.ToString();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(direction * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            score++;
            RandomPosition();
            
        }
        else if (collision.CompareTag("Obstacle"))
        {
            this.transform.position = Vector3.zero;
        }
    }
}
