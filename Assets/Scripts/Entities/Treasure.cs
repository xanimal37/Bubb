using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : Collectible,ITriggerable
{
    public override void Pickup(Player player) {
        Debug.Log("You picked up treasure!");

        player.treasure += 1;
        Destroy(gameObject);
    }

    public override void Drop(Player player) {
        player.treasure -= 1;
        Debug.Log("You dropped treasure!");
    }

    public void ProcessTrigger(Player player) { 
        Pickup(player);
    }

}
