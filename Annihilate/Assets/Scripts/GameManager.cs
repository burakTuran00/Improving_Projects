using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float levelupTime = 1.0f;

    private int amountGold = 0;

    public TextMeshProUGUI goldText;

    private int playerHealth = 1;

    public TextMeshProUGUI healthText;

    private void Awake()
    {
        goldText.text = "x" + amountGold.ToString();
        healthText.text = "x" + playerHealth.ToString();
    }

    public void AddGold()
    {
        amountGold += 1;
        goldText.text = "x" + amountGold.ToString();
    }

    public void DecreaseHealth()
    {
        playerHealth -= 1;
        healthText.text = "x" + playerHealth.ToString();

        if (playerHealth < 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public IEnumerator LevelUp()
    {
        yield return new WaitForSeconds(levelupTime);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            currentSceneIndex = 0;
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene (nextSceneIndex);
    }
}
