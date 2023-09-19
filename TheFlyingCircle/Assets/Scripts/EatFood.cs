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
    }
}
