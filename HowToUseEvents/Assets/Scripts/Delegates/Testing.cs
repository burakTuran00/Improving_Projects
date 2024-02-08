using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Testing : MonoBehaviour
{
    public delegate void TestDelegate();
    public delegate bool TestBoolDelegate(int i);

    private TestDelegate testDelegateFunction;
    private TestBoolDelegate testBoolDelegate;

    private Action testAction;
    private Action<int, float> testIntFloatAction;

    private Func<bool> testFunc;
    private Func<int, bool> testIntBoolFunc;

    private void Start()
    {
        testDelegateFunction = MyTestDelegateFunction;
        testDelegateFunction += MySecondTestDelegateFunction;

        testDelegateFunction();

        testBoolDelegate = MyTestBoolDelegateFunction;
        Debug.Log(testBoolDelegate(3));

        testDelegateFunction = delegate () { Debug.Log("Anonymous Method"); };
        testDelegateFunction();

        testDelegateFunction = () =>{ Debug.Log("Lambda Exp."); };
        testDelegateFunction();

        testBoolDelegate = (int i) => {return i < 5;};
        Debug.Log(testBoolDelegate(12));

        testIntFloatAction = (int i, float f) => { Debug.Log(i + " " + f); };

        testFunc = () => {return false;};
        testIntBoolFunc = (int i) => { return i > 5;};
    }

    private void MyTestDelegateFunction()
    {
        Debug.Log("MyTestDelegateFunction");
    }

    private void MySecondTestDelegateFunction()
    {
        Debug.Log("MySecondTestDelegateFunction");
    }

    private bool MyTestBoolDelegateFunction(int number)
    {
        return number < 5;
    }   
}
