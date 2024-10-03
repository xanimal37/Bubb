using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBubble : Bubble, ICollidable
{
    public void ProcessCollision(Player player) {
        player.size += size;
        Die();

    }
}
