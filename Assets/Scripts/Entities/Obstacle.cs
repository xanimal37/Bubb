using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, ICollidable
{
  public void ProcessCollision(Player player)
    {
        player.size -= .25f;
        player.KnockBack(gameObject.transform);
    }
}
