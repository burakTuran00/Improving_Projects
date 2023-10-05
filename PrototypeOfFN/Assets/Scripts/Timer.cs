using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private LevelManager levelManager;

    private Spawner spawner;

    [Range(0, 10)]
    public int taskMinute;

    [Range(0, 60)]
    public int taskSecond;

    public TextMeshProUGUI minuteText;

    public TextMeshProUGUI secondText;

    private void Awake()
    {
        spawner = FindAnyObjectByType<Spawner>();
        levelManager = GetComponent<LevelManager>();

        minuteText.text = taskMinute.ToString("00");
        secondText.text = taskSecond.ToString("00");
    }

    private void Start()
    {
        StartCoroutine(AdjustTime());
    }

    IEnumerator AdjustTime()
    {
        while (true)
        {
            if (taskSecond != 0)
            {
                taskSecond--;
                secondText.text = taskSecond.ToString("00");
                yield return new WaitForSeconds(1f);

                if (taskMinute <= 0 && taskSecond <= 0)
                {
                    taskMinute = 0;
                    taskSecond = 0;

                    if(levelManager.IsLevelCompleted())
                    {
                        Debug.Log("Level Up");
                        //todo : next level at Gamemanager or Menu System, I'll think about it
                    }
                    else
                    {
                        Debug.Log("Again");
                        //todo: player will be play again. Little Menu System
                    }

                    spawner.StopSpawner();
                    Debug.Log("Spawner stop");

                    break;
                }
            }
            else
            {
                taskMinute--;
                minuteText.text = taskMinute.ToString("00");

                taskSecond = 60;
                secondText.text = taskSecond.ToString("00");
            }
        }
    }
}
