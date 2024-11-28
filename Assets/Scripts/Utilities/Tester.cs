using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tester : MonoBehaviour
{
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        Timer newTimer = new Timer(10);
        coroutine = newTimer.RunTimer();
        newTimer.SetAction(PrintStuff);
        StartCoroutine(coroutine);
    }

    private void PrintStuff()
    {
        Debug.Log("I printed something.");
    }

    
}
