using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image[] healthImages;

    public int health = 3;

    private ShowItemToCut showItemToCut;

    private Timer timer;

    private Spawner spawner;

    private LevelManager levelManager;

    private GameManager gameManager;

    private void Awake()
    {
        showItemToCut = FindAnyObjectByType<ShowItemToCut>();
        timer = FindAnyObjectByType<Timer>();
        spawner = FindAnyObjectByType<Spawner>();
        levelManager = FindAnyObjectByType<LevelManager>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void TakeHealth()
    {
        health--;
        healthImages[health].color = Color.black;

        if (health <= 0)
        {
            showItemToCut.ShowGameEndValues();
            timer.StopTimer();
            spawner.StopSpawner();

            levelManager.AdjustItemEndOfTheGame();

            gameManager.restartButtonObject.SetActive(true);
            gameManager.startButtonObject.SetActive(false);
            gameManager.nextButtonObject.SetActive(false);
            gameManager.MenuButton.SetActive(true);

            levelManager.levelUpText.enabled = true;
            levelManager.levelUpText.text = "TRY AGAIN!";
        }
    }
}
