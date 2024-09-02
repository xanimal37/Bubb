using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectible 
{
    public void PickUp(Player p);

    public void Drop(Player p);

    public void Process(Player p);
}
