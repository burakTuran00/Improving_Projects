using UnityEngine;

public class IncreaseLevel : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            gameManager.NextLevel();
            Destroy(this.gameObject);
        }
    }
}
