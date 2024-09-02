using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public virtual void Pickup(Player player) { }

    public virtual void Drop(Player player) { }
}
