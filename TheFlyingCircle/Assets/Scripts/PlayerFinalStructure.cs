using System.Collections.Generic;
using UnityEngine;

public class PlayerFinalStructure : MonoBehaviour
{
    public Joystick joystick;

    private Vector3 direction;

    public float forwardSpeed = 1.0f;

    public float leftRightSpeed = 1.0f;

    public bool isMovable;

    private GameManager gameManager;

    private void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (isMovable)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);

            float xMovement = -joystick.Horizontal * leftRightSpeed * Time.deltaTime;
            float zMovement = -joystick.Vertical * forwardSpeed * Time.deltaTime;

            transform.position += new Vector3(xMovement, 0f, zMovement);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bot"))
        {
            if (gameManager != null && gameManager.score > 0 && other.gameObject != null)
            {
                gameManager.score--;
                gameManager.scoreText.text = gameManager.score.ToString();

                gameManager.botNumber--;

                if(gameManager.score <= 0 && gameManager.botNumber > 0)
                {
                    gameManager.Restart();
                }
                else if(gameManager.score >= 0 && gameManager.botNumber <= 0)
                {
                    gameManager.NextLevel();
                }

                other.gameObject.GetComponent<AudioSource>().Play();
                other.gameObject.GetComponentInChildren<Animator>().SetTrigger("Destroy");
                other.gameObject.GetComponent<Rigidbody>().useGravity = true;

                Destroy(other.gameObject, 2f);
            }
            else
            {
                return;
            }
        }
    }

  
}
