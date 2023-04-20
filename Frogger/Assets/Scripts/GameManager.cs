using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Frogger frogger;

    private Home[] homes;

    private int score;

    private int lives;

    private void Awake()
    {
        homes = FindObjectsOfType<Home>();
        frogger = FindObjectOfType<Frogger>();
    }

    private void NewGame()
    {
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

    public void HomeOccupied()
    {
        frogger.gameObject.SetActive(false);

        if (Cleared())
        {
            Invoke(nameof(NewLevel), 1f);
        }
        else
        {
            Invoke(nameof(NewRound), 1f);
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

    private void NewRound()
    {
        frogger.Respawn();
    }

    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }
}
