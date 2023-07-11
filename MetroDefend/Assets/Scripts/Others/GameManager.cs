using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public float delay = 1.0f;

    private void Awake()
    {
        int numberGameManager = FindObjectsOfType<GameManager>().Length;

        if (numberGameManager > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void RestartLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(SceneLoader(currentIndex));
    }

    public void NextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;
        StartCoroutine(SceneLoader(nextIndex));
    }

    private IEnumerator SceneLoader(int sceneIndex)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene (sceneIndex);
    }
}
