using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private Ammo ammo;

    private float waitTime = 1f;

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

        ammo = FindObjectOfType<Ammo>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public void NewGame()
    {
        StartCoroutine(LoadNextLevel());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadUILevel()
    {
        StartCoroutine(FirsLevel());
    }

    public IEnumerator FirsLevel()
    {
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(0);
    }

    private IEnumerator LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene (nextSceneIndex);
    }
}
