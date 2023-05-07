using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private Ammo ammo;

    private GameObject gameManagerCanvas;

    private GameObject playerCanvas;

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
        ammo.ammoAmount = 30;
        playerHealth.health = 100;
        gameManagerCanvas.SetActive(false);
    }

    public void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene (currentSceneIndex);
    }
}
