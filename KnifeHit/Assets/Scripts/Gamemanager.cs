using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    [SerializeField]
    private Fruit[] fruits;

    private int fruitsNumber;

    [SerializeField]
    private Thrower thrower;

    private void Awake()
    {
        fruitsNumber = fruits.Length;
    }

    public void DecreaseFruit()
    {
        fruitsNumber--;
        Debug.Log (fruitsNumber);

        if (fruitsNumber <= 0 && thrower.GetIndex() > 0)
        {
            NextLevel();
        }
        else if (fruitsNumber > 0 && thrower.GetIndex() <= 0)
        {
            RestartLevel();
        }
        else
        {
            return;
        }
    }

    public void IsLevelEnd()
    {
        
    }
    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (currentSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            currentSceneIndex = 0;
            nextSceneIndex = 0;
        }

        LoadScene (nextSceneIndex);
    }

    public void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        LoadScene (currentSceneIndex);
    }

    private void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene (sceneIndex);
    }
}
