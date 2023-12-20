using System;
using UnityEngine;

public class TestingEventSubscriber : MonoBehaviour
{
    private TestingEvents testingEvents;

    private void Start()
    {
        testingEvents = GetComponent<TestingEvents>();

        testingEvents.OnSpacePressed += TestingEvents_OnSpacePressed; // Subscribe
        testingEvents.OnFloatEvent += TestingEvents_OnFloatEvent;
        testingEvents.OnActionEvent += TestingEvents_OnActionEvent;
    }

    private void TestingEvents_OnSpacePressed(object sender, TestingEvents.OnSpacePressedEventArgs e)
    {
        Debug.Log("Space! "+ e.spaceCount);
        testingEvents.OnSpacePressed -= TestingEvents_OnSpacePressed; // Unsubscribe, doesn't work 
    }

    private void TestingEvents_OnFloatEvent(float f)
    {
        Debug.Log("Float: " + f);
        testingEvents.OnFloatEvent -= TestingEvents_OnFloatEvent;
    }
    private void TestingEvents_OnActionEvent(bool arg1, int arg2)
    {
        Debug.Log(arg2 + " " + arg1);
    }

    public void TestingUnityEvent()
    {
        Debug.Log("Unity Event");
    }
}
