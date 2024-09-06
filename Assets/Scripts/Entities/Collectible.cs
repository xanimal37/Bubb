using UnityEngine;
using System;

public class Collectible : MonoBehaviour, ITriggerable
{
    public GameEvent pickedUp;

    public virtual void OnTriggerEnter(Collider other)
    {
        pickedUp.Occurred();
        Destroy(gameObject);
    }

   
}
