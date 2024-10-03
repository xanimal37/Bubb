using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, ICollidable
{
  public void ProcessCollision(Player player)
    {
        Debug.Log("HIT AN OBSTACLE");
    }
}
