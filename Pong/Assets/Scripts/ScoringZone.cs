using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScoringZone : MonoBehaviour
{

    public EventTrigger.TriggerEvent scoreTriger;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            BaseEventData baseEventData = new BaseEventData(EventSystem.current);
            this.scoreTriger.Invoke(baseEventData);
        }
    }
}
