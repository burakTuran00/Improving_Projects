using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Frogger frogger;

    private Home[] homes;

    public GameObject gameOverMenu;

    public Text scoreText;

    public Text livesText;

    public Text timeText;

    private int score;

    private int lives;

    private int time;

    private void Awake()
    {
        homes = FindObjectsOfType<Home>();
        frogger = FindObjectOfType<Frogger>();
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        gameOverMenu.SetActive(false);

        SetScore(0);
        SetLives(3);

        NewLevel();
    }

    private void NewLevel()
    {
        for (int i = 0; i < homes.Length; i++)
        {
            homes[i].enabled = false;
        }

        NewRound();
    }

    private void NewRound()
    {
        Respawn();
    }

    private void Respawn()
    {
        frogger.Respawn();

        StopAllCoroutines();
        StartCoroutine(Timer(30));
    }

    IEnumerator Timer(int duration)
    {
        time = duration;

        while (time > 0)
        {
            yield return new WaitForSeconds(1);

            time--;
            timeText.text = time.ToString();
        }

        frogger.Death();
    }

    public void Died()
    {
        SetLives(lives - 1);

        if (lives > 0)
        {
            Invoke(nameof(Respawn), 1f);
        }
        else
        {
            Invoke(nameof(GameOver), 1f);
        }
    }

    private void GameOver()
    {
        frogger.gameObject.SetActive(false);
        gameOverMenu.SetActive(true);

        StartCoroutine(CheckForPlayAgain());
    }

    IEnumerator CheckForPlayAgain()
    {
        bool playAgain = false;

        while (!playAgain)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                playAgain = true;
            }

            yield return null;
        }

        NewGame();
    }

    public void AdvancedRow()
    {
        SetScore(score + 10);
    }

    public void HomeOccupied()
    {
        frogger.gameObject.SetActive(false);

        int bonusPoints = time * 20;
        SetScore(score + bonusPoints + 50);

        if (Cleared())
        {
            SetScore(score + 1000);
            SetLives(lives + 1);
            Invoke(nameof(NewLevel), 1f);
        }
        else
        {
            Invoke(nameof(Respawn), 1f);
        }
    }

    private bool Cleared()
    {
        for (int i = 0; i < homes.Length; i++)
        {
            if (!homes[i].enabled)
            {
                return false;
            }
        }

        return true;
    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString();
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        livesText.text = lives.ToString();
    }
}
