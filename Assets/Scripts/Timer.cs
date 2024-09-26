using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
public class Timer
{
    public Action methodToCall; //no return type for Action
    //
    private float timeToWait;

    public Timer(float seconds)
    {
        timeToWait = seconds;
    }

    public void SetAction(Action action) {
        methodToCall = action;
    }

    public IEnumerator RunTimer()
    {
        yield return new WaitForSecondsRealtime(timeToWait);
        methodToCall();
    }

    



   

    
       
    
}
