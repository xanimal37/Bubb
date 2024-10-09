using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Environment, ICollidable
{
  public void ProcessCollision(Player player)
    {
        
        environmentInteraction.Invoke("Collided with an obstacle!");
    }
}
