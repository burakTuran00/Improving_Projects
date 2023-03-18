using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    public int playerLives = 3;

    private void Awake()
    {
        int numberGameSession = FindObjectsOfType<GameSession>().Length;

        if (numberGameSession > 1)
        {
            Destroy (gameObject);
        }
        else
        {
            DontDestroyOnLoad (gameObject);
        }
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0); // First Level
        Destroy (gameObject);
    }

    private void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene (currentSceneIndex);
    }
}
