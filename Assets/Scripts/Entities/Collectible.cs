using UnityEngine;
using System;
using UnityEditor.Rendering;

public abstract class Collectible : MonoBehaviour, ITriggerable
{
    public CollectibleEvent pickUp;


    public void ProcessTriggerEntered(Player player)
    {
        pickUp.Occurred(this);
        Destroy(gameObject);

    }

    public void ProcessTriggerExited(Player p)
    {

    }
}

  
