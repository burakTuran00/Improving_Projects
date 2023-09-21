using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Animations;

public class EatFood : MonoBehaviour
{
    private GameManager gameManager;

    private SphereCollider playerCollider;

    private void Awake()
    {
        playerCollider = GetComponent<SphereCollider>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            Food food = other.gameObject.GetComponent<Food>();

            food.PlayEatAudio();
            gameManager.IncreaseScore(food.value);

            transform.localScale *= (1 + food.scalValue);

            FindAnyObjectByType<FollowingCamare>().Dist.z -= food.scalValue;
        }
        else if(other.gameObject.CompareTag("Obstacle"))
        {
            FindObjectOfType<GameManager>().Restart();
        }
         if (other.gameObject.CompareTag("Bot"))
        {
            if (gameManager != null && gameManager.score > 0 && other.gameObject != null)
            {
                gameManager.DecreaseScor(1);

                gameManager.botNumber--;

                if(gameManager.score <= 0 && gameManager.botNumber > 0)
                {
                    gameManager.Restart();
                }
                else if(gameManager.score > 0 && gameManager.botNumber <= 0)
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
