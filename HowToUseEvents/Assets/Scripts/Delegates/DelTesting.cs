using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DelTesting : MonoBehaviour
{
    [SerializeField]
    private ActionOnTimer actionOnTimer;

    private bool hasTimerElapsed;

    private void Start()
    {
        actionOnTimer.SetTimer(1f, () => { Debug.Log("Timer complete!");});
    }

   
}
