using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seaweed : MonoBehaviour, ITriggerable
{
    public void ProcessTriggerEntered(Player p)
    {
        Debug.Log("HIT SEAWEED!");
        p.GetPlayerInput().SetDrag(3.0f);
    }

    public void ProcessTriggerExited(Player p) {
        p.GetPlayerInput().SetDrag(0.1f);
        Debug.Log("OUT OF SEAWEED!");
    }
}
