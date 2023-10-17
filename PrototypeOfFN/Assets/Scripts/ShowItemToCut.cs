using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShowItemToCut : MonoBehaviour
{
    private LevelManager levelManager;

    public GameObject TaskPanel;

    public GameObject startButtonObject;

    private Spawner spawner;

    private GameManager gameManager;

    [Header("Task Panel 1")]
    public TextMeshProUGUI[] texts;

    public Image[] images;

    public Sprite[] icons;
    private void Awake()
    {
        levelManager = FindAnyObjectByType<LevelManager>();
        spawner = FindAnyObjectByType<Spawner>();
    }

    private void Start()
    {
        AdjustInfoToPlayerBeforeStartGame();
    }

    public void AdjustInfoToPlayerBeforeStartGame()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].sprite = icons[i];
        }

        ShowInfoCountValue(texts[0], levelManager.taskAppleCount,"ORDERED");
        ShowInfoCountValue(texts[1], levelManager.taskWatermelonCount,"ORDERED");
        ShowInfoCountValue(texts[2],levelManager.taskLemonCount,"ORDERED");
        ShowInfoCountValue(texts[3], levelManager.taskPearCount,"ORDERED");
        ShowInfoCountValue(texts[4],levelManager.taskOnionCount,"ORDERED");
    }
    public void ShowGameEndValues()
    {
  
        ShowInfoCountValue(texts[0], levelManager.taskAppleCount,"REMAİNED");
        ShowInfoCountValue(texts[1], levelManager.taskWatermelonCount,"REMAİNED");      
        ShowInfoCountValue(texts[2], levelManager.taskLemonCount,"REMAİNED");
        ShowInfoCountValue(texts[3], levelManager.taskPearCount,"REMAİNED");
        ShowInfoCountValue(texts[4], levelManager.taskOnionCount,"REMAİNED");

        TaskPanel.SetActive(true);
        startButtonObject.SetActive(true);
    }
    
    private void ShowInfoCountValue(TextMeshProUGUI text, int value, string sentence)
    {
        if(value < 0)
        {
            value = 0;
        }

        text.text = "X" + value + " " + sentence;
    }
}
