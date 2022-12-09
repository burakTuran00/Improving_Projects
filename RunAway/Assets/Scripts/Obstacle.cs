using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public GameObject ball_Prefab;
    private int player_Health = 3;

    private void Awake()
    {
        RandomPosition();
    }
    private void Update()
    {
        if (player_Health <= 0)
        {
            Debug.Log("Game Over." + player_Health.ToString());
        }
    }

    public void RandomPosition()
    {
        float x = Random.Range(-10, 10);
        this.transform.position = new Vector2(x, 5.35f);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            RandomPosition();
            
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            player_Health--;
            RandomPosition();
        }
       
    }


}
