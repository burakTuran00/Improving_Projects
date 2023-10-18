using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI tempInfoText;

    public TextMeshProUGUI levelUpText;

    public bool isLevelCompleted = false;

    private Timer timer;

    private GameManager gameManager;

    [Header("Level Tasks")]
    public int taskAppleCount;

    public int taskWatermelonCount;

    public int taskAvacadoCount;

    public int taskCoconutCount;

    public int taskLemonCount;

    public int taskPearCount;

    public int taskOnionCount;

    [Header("Icons")]
    public Image iconImage;
    public Color invisibleIconColor;
    public Sprite[] iconSprites;
    
    private void Awake()
    {
        timer = GetComponent<Timer>();  
        gameManager = GetComponent<GameManager>(); 
    }

    public void DecreaseItemCount(string typeName)
    {
        if (typeName == "Apple")
        {
            taskAppleCount--;
            Adjust (taskAppleCount, typeName, iconSprites[0]);
        }
        else if (typeName == "Watermelon")
        {
            taskWatermelonCount--;
            Adjust (taskWatermelonCount, typeName,iconSprites[1]);
        }
        else if (typeName == "Avacado")
        {
            taskAvacadoCount--;
            Adjust (taskAvacadoCount, typeName,iconSprites[2]);
        }
        else if (typeName == "Coconut")
        {
            taskCoconutCount--;
            Adjust (taskCoconutCount, typeName,iconSprites[3]);
        }
        else if (typeName == "Lemon")
        {
            taskLemonCount--;
            Adjust (taskLemonCount, typeName,iconSprites[4]);
        }
        else if (typeName == "Pear")
        {
            taskPearCount--;
            Adjust (taskPearCount, typeName,iconSprites[5]);
        }
        else if(typeName == "Onion")
        {
            taskOnionCount--;
            Adjust(taskOnionCount,typeName,iconSprites[6]);
        }
        else
        {
            return;
        }

        IsLevelEnd();  
        //todo: show player icon such as apple, pear, etc.
    }

    private void Adjust(int taskValue, string typeName, Sprite icon)
    {
        if (taskValue >= 0)
        {
            StartCoroutine(ShowTempInfo(taskValue,typeName,icon));
        }
        else
        {
            StartCoroutine(timer.NegativeEffectToTimer());
            return;
        }
    }

    IEnumerator ShowTempInfo(int taskValue, string typeName,Sprite icon)
    {
        tempInfoText.enabled = true;
        tempInfoText.text = "+" + taskValue + " " + typeName.ToString() +" remain!";

        if(taskValue <= 0)
        {
            tempInfoText.text = typeName.ToString() + " completed!";
            //tempInfoText.color = Color.red;

            //todo: if player cuts the exact number of that object, show it different such as 
            // color may be red or like that 
        }

        iconImage.color = Color.white;
        iconImage.sprite = icon;

        yield return new WaitForSecondsRealtime(.5f);

        tempInfoText.enabled = false;
        iconImage.sprite = null;
        iconImage.color = invisibleIconColor;
        
        StopAllCoroutines();
    }

    public void IsLevelEnd()
    {
        if(IsLevelCompleted())
        {            
            FindAnyObjectByType<Spawner>().StopSpawner();
            timer.StopTimer();
            FindAnyObjectByType<ShowItemToCut>().ShowGameEndValues();

            gameManager.restartButtonObject.SetActive(false);
            gameManager.startButtonObject.SetActive(false);
            gameManager.nextButtonObject.SetActive(true);
            gameManager.MenuButton.SetActive(true);

            AdjustItemEndOfTheGame();
        }
    }

    public bool IsLevelCompleted()
    {
        if(taskAppleCount <= 0 && taskAvacadoCount <= 0 && taskCoconutCount <= 0 &&
           taskLemonCount <= 0 && taskPearCount <= 0 && taskWatermelonCount <= 0 && 
           taskOnionCount <= 0)
           {
                isLevelCompleted = true;
                levelUpText.enabled = true;
           }

        return isLevelCompleted;
    }

    public void AdjustItemEndOfTheGame()
    {
        // when player ends the game, if there's a fruit or bomb in the scene
        // player cannot cut that object.

        Fruit[] fruits = FindObjectsOfType<Fruit>();

        foreach (Fruit fruit in fruits)
        {
            Destroy(fruit.GetComponent<Fruit>());
        }

        Bomb[] bombs = FindObjectsOfType<Bomb>();

        foreach (Bomb bomb in bombs)
        {
            Destroy(bomb.GetComponent<Bomb>());
        }
    }
}
// if player cuts more item than mission task, then time will be reduce like -5 seconds.