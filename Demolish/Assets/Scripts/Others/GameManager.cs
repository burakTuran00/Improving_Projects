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
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        SceneManager.LoadScene (nextSceneIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayerDieStage()
    {
        SceneManager.LoadScene(0);
    }
}
