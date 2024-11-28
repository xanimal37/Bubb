using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBubble : Bubble, ICollidable
{
    private float damage = -0.25f;

    public override void ProcessCollision(Player player) {
        player.GetPlayerSize().UpdateSize(damage);
        Die();
    }
    

}
