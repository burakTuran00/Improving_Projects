using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Blaster blaster;

    private Centipede centipede;

    private MushroomField mushroomField;

    private int score;

    private int lives;

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
        score = 0;
        lives = 3;

        centipede.Respawn();
        blaster.Respawn();
        mushroomField.ClearField();
        mushroomField.Generate();
    }

    public void GameOver()
    {
        blaster.gameObject.SetActive(false);
    }

    public void ResetRound()
    {
        lives--;

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
}
