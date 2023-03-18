using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    private int playerLives = 3;

    private float score = 0.0f;

    public TextMeshProUGUI livesText;

    public TextMeshProUGUI scoreText;

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

    private void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    public void IncreaseScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
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
        livesText.text = playerLives.ToString();
    }
}
