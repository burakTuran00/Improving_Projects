using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int levelSecond;

    public int levelMinute;

    private LevelManager levelManager;

    private GameManager gameManager;

    private Spawner spawner;

    private ShowItemToCut showItemToCut;

    private Health playerHealth;

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
        gameManager = GetComponent<GameManager>();
        playerHealth = FindAnyObjectByType<Health>();

        TimerReset();
    }

    public void TimerReset()
    {
        taskMinute = levelMinute;
        taskSecond = levelSecond;

        minuteText.text = taskMinute.ToString("00");
        secondText.text = taskSecond.ToString("00");
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

    public void StartTimer()
    {
        StartCoroutine(AdjustTime());
    }

    public void StopTimer()
    {
        StopAllCoroutines();

        if (taskSecond >= 0 && playerHealth.health >= 0)
        {
            secondText.color = Color.green;
            minuteText.color = Color.green;
        }
        else
        {
            secondText.color = Color.red;
            minuteText.color = Color.red;
        }
    }

    IEnumerator AdjustTime()
    {
        while (true)
        {
            if (!(taskSecond < 0))
            {
                taskSecond--;
                secondText.text = taskSecond.ToString("00");
                yield return new WaitForSeconds(1f);

                if (taskMinute <= 0 && taskSecond <= 0)
                {
                    taskMinute = 0;
                    taskSecond = 0;

                    if (levelManager.IsLevelCompleted())
                    {
                        gameManager.restartButtonObject.SetActive(false);
                        gameManager.startButtonObject.SetActive(false);
                        gameManager.nextButtonObject.SetActive(true);
                        gameManager.MenuButtonObject.SetActive(true);
                        //todo : next level at Gamemanager or Menu System, I'll think about it
                    }
                    else
                    {
                        gameManager.restartButtonObject.SetActive(true);
                        gameManager.startButtonObject.SetActive(false);
                        gameManager.nextButtonObject.SetActive(false);
                        gameManager.MenuButtonObject.SetActive(true);

                        levelManager.levelUpText.enabled = true;
                        levelManager.levelUpText.text = "TRY AGAIN!";
                        //todo: player will be play again. Little Menu System
                    }

                    spawner.StopSpawner();
                    secondText.text = "00";
                    minuteText.text = "00";

                    showItemToCut.ShowGameEndValues();
                    levelManager.AdjustItemNoCuttable();

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
