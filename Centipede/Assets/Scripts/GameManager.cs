using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Blaster blaster;

    private Centipede centipede;

    private MushroomField mushroomField;

    private int score;

    private int lives;

    public Text scoreText;

    public Text livesText;

    public GameObject gameOverMenu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy (gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        blaster = FindObjectOfType<Blaster>();
        centipede = FindObjectOfType<Centipede>();
        mushroomField = FindObjectOfType<MushroomField>();

        NewGame();
    }

    private void Update()
    {
        if (lives <= 0 && Input.anyKeyDown)
        {
            NewGame();
        }
    }

    public void NewGame()
    {
        SetScore(0);
        SetLives(3);

        centipede.Respawn();
        blaster.Respawn();
        mushroomField.ClearField();
        mushroomField.Generate();

        gameOverMenu.SetActive(false);
    }

    public void GameOver()
    {
        blaster.gameObject.SetActive(false);
        gameOverMenu.SetActive(true);
    }

    public void ResetRound()
    {
        SetLives(lives - 1);

        if (lives <= 0)
        {
            GameOver();
            return;
        }

        centipede.Respawn();
        blaster.Respawn();
        mushroomField.Heal();
    }

    public void NextLevel()
    {
        centipede.speed *= 1.12f;
        centipede.Respawn();
    }

    public void IncreaseScore(int amount)
    {
        SetScore(score + amount);
    }

    private void SetScore(int value)
    {
        score = value;
        scoreText.text = score.ToString();
    }

    private void SetLives(int value)
    {
        lives = value;
        livesText.text = lives.ToString();
    }
}
