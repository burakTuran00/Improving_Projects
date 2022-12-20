using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float gameSpeed { get; private set; }
    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = .1f;

    private Player player;
    private Spawner spawner;

    public TextMeshProUGUI gameover_Text;
    public Button retry_Button;
    public TextMeshProUGUI score_Text;

    public float score = 0f;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
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
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();

        NewGame();
    }
    public void NewGame()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        foreach (var item in obstacles)
        {
            Destroy(item.gameObject);
        }

        gameSpeed = initialGameSpeed;
        enabled = true;
        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameover_Text.gameObject.SetActive(false);
        retry_Button.gameObject.SetActive(false);

    }
    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        score_Text.text = Mathf.FloorToInt(score).ToString("D5");
    }
    public void GameOver()
    {
        score = 0;
        score_Text.text = score.ToString();
        gameSpeed = 0f;
        enabled = false;
        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        gameover_Text.gameObject.SetActive(true);
        retry_Button.gameObject.SetActive(true);
        
    }
}
