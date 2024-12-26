using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Current : MonoBehaviour, ITriggerable
{
    public void ProcessTriggerEntered(Player p)
    {
        Debug.Log("Triggered current!");
        //continuous force upward
        p.GetPlayerInput().ToggleIsInCurrent(true);
    }

    public void ProcessTriggerExited(Player p) {
        Debug.Log("Exited the current.");
        p.GetPlayerInput().ToggleIsInCurrent(false);
    }

}
