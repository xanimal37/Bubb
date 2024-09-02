using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Artefact : Collectible, ITriggerable
{
    public override void Pickup(Player player) {
       
            player.hasArtefact = true;
            Destroy(gameObject);
            Debug.Log("You picked up an artefact!");
    }

    public override void Drop(Player player) {
        player.hasArtefact = false;
        Debug.Log("You dropped an artefact!");
    }

    public void ProcessTrigger(Player player) {
        Pickup(player);
    }
}
