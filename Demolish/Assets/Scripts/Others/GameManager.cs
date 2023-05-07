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

    private float waitTime = 1.0f;

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

    public void RestartLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene (currentIndex);
    }

    public void NextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;
        SceneManager.LoadScene (nextIndex);
    }

    private IEnumerator SceneLoader(int sceneIndex)
    {
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene (sceneIndex);
    }
}
