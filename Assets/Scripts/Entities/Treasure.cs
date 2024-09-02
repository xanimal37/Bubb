using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour, ICollectible
{
    public void PickUp(Player p) {
        Debug.Log("You picked up treasure!");

        p.treasure += 1;
    }

    public void Drop(Player p) {
        p.treasure -= 1;
        Debug.Log("You dropped treasure.");
    }

    public void Process(Player player) {
        Destroy(gameObject);
    }
}
