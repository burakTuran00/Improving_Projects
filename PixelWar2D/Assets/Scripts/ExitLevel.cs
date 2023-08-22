using System.Collections;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    private GameManager gameManager;

    public float delay = 1.0f;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LoadNextLevel());
        }
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(delay);
        gameManager.NextLevel();
    }
}
