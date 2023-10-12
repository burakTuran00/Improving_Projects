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

        ShowInfoBeforeStartTaskCount(texts[0], levelManager.taskAppleCount);
        ShowInfoBeforeStartTaskCount(texts[1], levelManager.taskWatermelonCount);
        ShowInfoBeforeStartTaskCount(texts[2],levelManager.taskLemonCount);
        ShowInfoBeforeStartTaskCount(texts[3], levelManager.taskPearCount);
        ShowInfoBeforeStartTaskCount(texts[4],levelManager.taskOnionCount);
    }

    private void ShowInfoBeforeStartTaskCount(TextMeshProUGUI text, int value)
    {
        if(value < 0)
        {
            value = 0;
        }

        text.text = "X" + value.ToString() + " ORDERED";
    }

    public void ShowGameEndValues()
    {
  
        ShowGameEndValue(texts[0], levelManager.taskAppleCount);
        ShowGameEndValue(texts[1], levelManager.taskWatermelonCount);      
        ShowGameEndValue(texts[2], levelManager.taskLemonCount);
        ShowGameEndValue(texts[3], levelManager.taskPearCount);
        ShowGameEndValue(texts[4], levelManager.taskOnionCount);

        TaskPanel.SetActive(true);
        startButtonObject.SetActive(true);
    }

    private void ShowGameEndValue(TextMeshProUGUI text, int value)
    {
        if (value < 0)
        {
            value = 0;
        }

        text.text = "X" + value + " REMAİNED";
    }

}
