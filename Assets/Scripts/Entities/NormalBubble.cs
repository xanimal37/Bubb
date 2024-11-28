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
        //divid bubble size so it's not so huge
        float sizeforPlayer = size / 2;
        player.GetPlayerSize().UpdateSize(sizeforPlayer);
        Die();
    }
   
}
