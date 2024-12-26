using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBubble : Bubble, ICollidable
{
    public override void ProcessCollision(Player player) {
        player.GetPlayerSize().UpdateSize(bubbleSize,true);
        
        Die();
    }
    

}
