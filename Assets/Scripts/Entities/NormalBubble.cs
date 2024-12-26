using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBubble : Bubble
{
    public override void Die()
    {
        NormalBubblePool.Pool.ReturnToPool(this);
        base.Die();
    }

    public override void ProcessCollision(Player player)
    {
        player.GetPlayerSize().UpdateSize(bubbleSize, false);
        Die();
    }
   
}
