using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBubble : Bubble, ICollidable
{

    public void ProcessCollision(Player player) {
        player.size -= .25f;
        Die();
    }
    

}
