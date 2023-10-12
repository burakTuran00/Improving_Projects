using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowItemToCut : MonoBehaviour
{
    private LevelManager levelManager;

    public GameObject TaskPanel;

    [Header("Task Panel 1")]
    public TextMeshProUGUI[] texts;

    public Image[] images;

    public Sprite[] icons;

    private void Awake()
    {
        levelManager = FindAnyObjectByType<LevelManager>();
    }

    private void Start()
    {
        StartCoroutine(AdjustInfoToPlayerBeforeStartGame());
    }

    IEnumerator AdjustInfoToPlayerBeforeStartGame()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].sprite = icons[i];
        }

        texts[0].text = "X" + levelManager.taskAppleCount + " ORDERED";
        texts[1].text = "X" + levelManager.taskWatermelonCount + " ORDERED";
        texts[2].text = "X" + levelManager.taskLemonCount + " ORDERED";
        texts[3].text = "X" + levelManager.taskPearCount + " ORDERED";
        texts[4].text = "X" + levelManager.taskOnionCount + " ORDERED";

        yield return new WaitForSeconds(2.5f);

        TaskPanel.SetActive(false);
    }

    public void ShowGameEndValues()
    {
  
        ShowGameEndValue(texts[0], levelManager.taskAppleCount);
        ShowGameEndValue(texts[1], levelManager.taskWatermelonCount);      
        ShowGameEndValue(texts[2], levelManager.taskLemonCount);
        ShowGameEndValue(texts[3], levelManager.taskPearCount);
        ShowGameEndValue(texts[4], levelManager.taskOnionCount);

        TaskPanel.SetActive(true);
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
