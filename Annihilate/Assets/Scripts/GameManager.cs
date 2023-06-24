using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float levelupTime = 1.0f;

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
