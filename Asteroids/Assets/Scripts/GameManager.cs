using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerMovement player;

    public ParticleSystem explosion;

    public int lives = 3;

    public float respanwRate = 1.75f;

    public float collisionWaitingTime = 5.0f;

    public int score = 0;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI livesText;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        explosion.transform.position = asteroid.transform.position;
        explosion.Play();

        if (asteroid.size < 0.75f)
        {
            score += 100;
        }
        else if (asteroid.size < 1.25f)
        {
            score += 50;
        }
        else
        {
            score += 25;
        }

        scoreText.text = score.ToString();
    }

    public void PlayerDied()
    {
        explosion.transform.position = player.transform.position;
        explosion.Play();

        lives--;
        livesText.text = lives.ToString();

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), respanwRate);
        }
    }

    private void Respawn()
    {
        player.transform.position = Vector3.zero;
        player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollision");
        player.gameObject.SetActive(true);

        Invoke(nameof(TurnOnCollision), collisionWaitingTime);
    }

    private void TurnOnCollision()
    {
        player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        lives = 3;
        score = 0;

        scoreText.text = score.ToString();
        livesText.text = lives.ToString();

        Invoke(nameof(Respawn), respanwRate);
    }
}
