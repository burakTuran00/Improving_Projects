using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float levelupTime = 1.0f;

    private int amountGold = 0;

    public TextMeshProUGUI goldText;

    public int playerHealth = 1;

    private void Awake()
    {
        goldText.text = "x" + amountGold.ToString();
    }

    public void AddGold()
    {
        amountGold += 1;
        goldText.text = "x" + amountGold.ToString();
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
