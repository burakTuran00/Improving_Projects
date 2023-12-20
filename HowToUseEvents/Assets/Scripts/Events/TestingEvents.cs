using System;
using UnityEngine;
using UnityEngine.Events;
public class TestingEvents : MonoBehaviour
{
    private int counter;

    #region Defination Of Generic Event With EventHandler
    public event EventHandler<OnSpacePressedEventArgs> OnSpacePressed;// .NET Standart Defination
    public class OnSpacePressedEventArgs : EventArgs {
        public int spaceCount;
    }
    #endregion

    #region  Defination Of Event With Delegate
    public delegate void TestEventDelegate(float f);
    public event TestEventDelegate OnFloatEvent;
    #endregion

    #region  Defination Of Event With Action
    public event Action<bool, int> OnActionEvent;
    #endregion

    #region Unity Event
    public UnityEvent OnUnityEvent;
    // Doesn't reqire subscribe, However you need to assign on editor.
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            counter++;
            OnSpacePressed?.Invoke(this, new OnSpacePressedEventArgs {spaceCount = counter}); 
            OnFloatEvent?.Invoke(5.5f);
            OnActionEvent?.Invoke(true, 3);
            OnUnityEvent?.Invoke();
        }
    }
}
