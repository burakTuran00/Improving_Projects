using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private LevelManager levelManager;

    private Spawner spawner;

    private ShowItemToCut showItemToCut;

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
        showItemToCut = FindAnyObjectByType<ShowItemToCut>();

        minuteText.text = taskMinute.ToString("00");
        secondText.text = taskSecond.ToString("00");
    }

    private void Start()
    {
        StartCoroutine(AdjustTime());
    }

    public IEnumerator NegativeEffectToTimer()
    {
        taskSecond -= 5;
        secondText.text = taskSecond.ToString("00");

        secondText.color = Color.red;
        minuteText.color = Color.red;

        yield return new WaitForSeconds(.25f);

        secondText.color = Color.white;
        minuteText.color = Color.white;
        
        StopCoroutine(NegativeEffectToTimer());
    }

    public void StopTimer()
    {
        StopAllCoroutines();

        if(taskSecond > 0)
        {
            secondText.color = Color.green;
            minuteText.color = Color.green;
        }
    }

    IEnumerator AdjustTime()
    {
        while (true)
        {
            if (taskSecond != 0 && !(taskSecond < 0))
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
                        FindAnyObjectByType<Blade>().StopSlicing();
                        //todo: player will be play again. Little Menu System
                    }

                    spawner.StopSpawner();
                    secondText.text = "00";

                    showItemToCut.ShowGameEndValues();

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
