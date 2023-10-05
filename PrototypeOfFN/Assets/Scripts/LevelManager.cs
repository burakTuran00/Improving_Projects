using UnityEngine;
using TMPro;
using System.Collections;
public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI tempInfoText;

    public TextMeshProUGUI levelUpText;

    public bool isLevelCompleted = false;

    [Header("Level Tasks")]
    public int taskAppleCount;

    public int taskWatermelonCount;

    public int taskAvacadoCount;

    public int taskCoconutCount;

    public int taskLemonCount;

    public int taskPearCount;

    public void DecreaseItemCount(string typeName)
    {
        if (typeName == "Apple")
        {
            taskAppleCount--;
            Adjust (taskAppleCount, typeName);
        }
        else if (typeName == "Watermelon")
        {
            taskWatermelonCount--;
            Adjust (taskWatermelonCount, typeName);
        }
        else if (typeName == "Avacado")
        {
            taskAvacadoCount--;
            Adjust (taskAvacadoCount, typeName);
        }
        else if (typeName == "Coconut")
        {
            taskCoconutCount--;
            Adjust (taskCoconutCount, typeName);
        }
        else if (typeName == "Lemon")
        {
            taskLemonCount--;
            Adjust (taskLemonCount, typeName);
        }
        else if (typeName == "Pear")
        {
            taskPearCount--;
            Adjust (taskPearCount, typeName);
        }
        else
        {
            return;
        }
    }

    private void Adjust(int taskValue, string typeName)
    {
        if (taskValue >= 0)
        {
            StartCoroutine(ShowText(taskValue,typeName));
            
        }
        else
        {
            return;
        }
    }

    IEnumerator ShowText(int taskValue, string typeName)
    {
        tempInfoText.enabled = true;
        tempInfoText.text = "+" + taskValue + " " + typeName.ToString() +" remain!";
        yield return new WaitForSecondsRealtime(.5f);
        tempInfoText.enabled = false;
        StopAllCoroutines();
    }

    public void IsLevelEnd()
    {
        if(isLevelCompleted)
        {
            levelUpText.enabled = true;
                // todo: stop  spawner
          }
    }

    public bool IsLevelCompleted()
    {
        if(taskAppleCount <= 0 && taskAvacadoCount <= 0 && taskCoconutCount <= 0 &&
           taskLemonCount <= 0 && taskPearCount <= 0 && taskWatermelonCount <= 0)
           {
                isLevelCompleted = true;
                levelUpText.enabled = true;
           }

        return isLevelCompleted;
    }
}
// if player cuts more item than mission task, then time will be reduce like -5 seconds.