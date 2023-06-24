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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinishLine"))
        {
            playerMovement.forwardDirection = Vector3.zero;
            StartCoroutine(gameManager.LevelUp());
        }
        else if (other.gameObject.CompareTag("UnderSpawn"))
        {
            StartCoroutine(UnderSpawn());
        }
    }

    IEnumerator UnderSpawn()
    {
        yield return new WaitForSeconds(delay);
        playerMovement.transform.position = Vector3.zero;
        playerMovement.forwardDirection = Vector3.forward;
    }
}
