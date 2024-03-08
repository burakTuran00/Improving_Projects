using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Threading;
public class Timer : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Pause = !Pause;
    }

    [SerializeField] private Text uiText;
    [SerializeField] private Image uiImage;
    [SerializeField] private Text uiExtraText;
    [SerializeField] private int Duration;
    private int remainingDuration;
    private bool Pause;

    private void Start()
    {
        Being (Duration);
    }

    private void Being(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while(remainingDuration >= 0)
        {
            if(!Pause)
            {
                uiText.text = $"{remainingDuration/ 60:00}:{remainingDuration % 60:00}";
                uiImage.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                remainingDuration--;
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }

        OnEnd();
    }

    private void OnEnd()
    {
        print("End");
    }

   public int getRemainingTime()
   {
        return remainingDuration;
   }

    public void getMoreTime(int second)
    {
        remainingDuration += second;

        // seperate 
        uiExtraText.gameObject.SetActive(true);
        uiExtraText.text = "+" + second.ToString("00");
    }
}
