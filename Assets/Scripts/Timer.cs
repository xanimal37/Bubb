using UnityEngine;
public class Timer
{
    private float seconds;
    private float timeStamp;
    public Timer(float seconds) {
        this.seconds = seconds;
        //time on creation
        timeStamp = Time.deltaTime;
    }
   private void Update()
    {
        if (Time.time - timeStamp > seconds) { 
        
        }
    }
}
