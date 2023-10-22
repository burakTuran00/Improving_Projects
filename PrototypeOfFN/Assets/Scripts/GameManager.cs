using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image fadeImage;

    public TextMeshProUGUI scoreText;

    private Blade blade;

    private Spawner spawner;

    private ShowItemToCut showItemToCut;

    private Timer timer;

    private LevelManager levelManager;

    private Health health;

    private int score = 0;

    [Header("ButtonS")]
    public Button startButton;

    public TextMeshProUGUI startButtonText;

    public GameObject startButtonObject;

    public GameObject restartButtonObject;

    public GameObject nextButtonObject;

    public GameObject MenuButtonObject;

    private void Awake()
    {
        blade = FindObjectOfType<Blade>();
        spawner = FindObjectOfType<Spawner>();
        showItemToCut = FindAnyObjectByType<ShowItemToCut>();
        timer = GetComponent<Timer>();
        levelManager = GetComponent<LevelManager>();
        health = FindAnyObjectByType<Health>();
    }

    private void Start()
    {
        NewGame();
    }

    public void StartButton()
    {
        spawner.StartSpawner();
        timer.StartTimer();

        showItemToCut.TaskPanel.SetActive(false);
        startButtonObject.SetActive(false);
        MenuButtonObject.SetActive(false);
    }

    public void RestartButton()
    {
        RestartLevel();
    }

    public void NextButton()
    {
        NextLevel();
    }

    public void ReturnMenuButton()
    {
        SceneManager.LoadScene(0); // return to the menu.
    }

    public void IncreaseScor(int point)
    {
        score += point;
        scoreText.text = score.ToString("00000");
    }

    public void NewGame()
    {
        Time.timeScale = 1f;

        blade.enabled = true;
        spawner.enabled = true;

        //score = 0;
        //scoreText.text = score.ToString("00000");
        ClearScene();
    }

    private void ClearScene()
    {
        Fruit[] fruits = FindObjectsOfType<Fruit>();

        foreach (Fruit fruit in fruits)
        {
            Destroy(fruit.gameObject);
        }

        Bomb[] bombs = FindObjectsOfType<Bomb>();

        foreach (Bomb bomb in bombs)
        {
            Destroy(bomb.gameObject);
        }
    }

    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            currentSceneIndex = 0;
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene (nextSceneIndex);
        //todo
    }

    public void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene (currentSceneIndex);
    }

    public void Explode()
    {
        blade.enabled = false;

        //spawner.enabled = false;
        spawner.StopSpawner();

        StartCoroutine(ExplodeSequence());
    }

    IEnumerator ExplodeSequence()
    {
        float elapsed = 0f;
        float duration = 0.5f;

        health.TakeHealth();
        StartCoroutine(timer.NegativeEffectToTimer());

        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.clear, Color.white, t);

            Time.timeScale = 1f - t;
            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }

        yield return new WaitForSecondsRealtime(1f);

        NewGame();

        elapsed = 0;

        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.white, Color.clear, t);

            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }

        if (!levelManager.IsLevelCompleted() && health.health > 0)
        {
            spawner.StartSpawner();
        }
    }
}
