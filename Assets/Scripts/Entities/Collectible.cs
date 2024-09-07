using UnityEngine;
using System;
using UnityEditor.Rendering;

public abstract class Collectible : MonoBehaviour, ITriggerable
{
    public CollectibleEvent pickUp;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickUp.Occurred(this);
            Destroy(gameObject);

        }
    }

  

   
}
