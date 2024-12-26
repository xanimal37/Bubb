using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour, ICollidable
{
    [SerializeField]
    private string collideMessage;

    public void ProcessCollision(Player player) {

        player.Win(collideMessage);
    }
}
