using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    public int playerLives = 3;

    public int score = 0;

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

    public void IncreaseScore(int value)
    {
        score += value;
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
        Debug.Log("Reseting...");
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0); // First Level
        Destroy (gameObject);
    }

    private void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene (currentSceneIndex);
        Debug.Log("Player Life " + playerLives.ToString());
    }
}
