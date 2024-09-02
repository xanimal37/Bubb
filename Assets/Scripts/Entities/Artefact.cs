using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Artefact : MonoBehaviour, ICollectible
{
    public void PickUp(Player p) {
       
            p.hasArtefact = true;
            Debug.Log("You picked up an artefact!");
    }

    public void Drop(Player p) {
        p.hasArtefact = false;
        Debug.Log("You dropped an artefact!");
    }

    public void Process(Player p)
    {
        Destroy(gameObject);
    }
}
