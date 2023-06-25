using System.Collections;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private GameManager gameManager;

    public float delay = 1.0f;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            gameManager.DecreaseHealth();
            StartCoroutine(UnderSpawn(1.0f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinishLine"))
        {
            playerMovement.forwardDirection = Vector3.zero;
            StartCoroutine(gameManager.LevelUp());
        }
        else if (other.gameObject.CompareTag("UnderSpawn"))
        {
            StartCoroutine(UnderSpawn(delay));
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            gameManager.AddGold();
        }
        else if (other.gameObject.CompareTag("PowerUp"))
        {
            PowerUp powerUp = other.gameObject.GetComponent<PowerUp>();

            if (gameManager.playerHealth < 0)
            {
                gameManager.DecreaseHealth();
            }

            if (powerUp.operaiton == '+')
            {
                gameManager.playerHealth += powerUp.value;
            }
            else if (powerUp.operaiton == '-')
            {
                gameManager.playerHealth -= powerUp.value;
            }
            else if (powerUp.operaiton == '/')
            {
                gameManager.playerHealth /= powerUp.value;
            }
            else if (powerUp.operaiton == '*')
            {
                gameManager.playerHealth *= powerUp.value;
            }

            gameManager.playerHealth = Mathf.Round(gameManager.playerHealth);
            gameManager.IncreaseHealth(gameManager.playerHealth);
        }
    }

    IEnumerator UnderSpawn(float delaytime)
    {
        yield return new WaitForSeconds(delaytime);
        playerMovement.transform.position = Vector3.zero;
        playerMovement.forwardDirection = Vector3.forward;
    }
}
