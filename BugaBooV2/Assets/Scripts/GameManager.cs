using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerLives = 3;

    public int playerGold = 0;

    public TextMeshProUGUI goldText;

    public TextMeshProUGUI livesText;

    private void Start()
    {
        goldText.text = playerGold.ToString();
        livesText.text = playerLives.ToString();
    }

    public void TakeGold()
    {
        playerGold++;
        goldText.text = playerGold.ToString();
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
        FindObjectOfType<GamePersist>().ResetScenePersist();
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
